using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kiuss.Domain.Shared.Interface;

namespace Kiuss.Domain.Shared.Model
{
  public abstract class ValueObject : IBitConvertable
  {
    protected abstract IEnumerable<object> GetAtomicValues();

    #region IBitConvertable
    byte[] IBitConvertable.ObjectToBytes()
    {
      var bytes = new List<byte[]>();
      using (var thisValues = GetAtomicValues().GetEnumerator())
      {
        while (thisValues.MoveNext())
        {
          if (thisValues.Current == null) continue;

          switch (thisValues.Current)
          {
            case Guid guidValue:
              bytes.Add(guidValue.ToByteArray());
              break;
            case bool boolValue:
              bytes.Add(BitConverter.GetBytes(boolValue));
              break;
            case int intValue:
              bytes.Add(BitConverter.GetBytes(intValue));
              break;
            case long longValue:
              bytes.Add(BitConverter.GetBytes(longValue));
              break;
            case float floatValue:
              bytes.Add(BitConverter.GetBytes(floatValue));
              break;
            case double doubleValue:
              bytes.Add(BitConverter.GetBytes(doubleValue));
              break;
            case string strValue:
              bytes.Add(Encoding.Unicode.GetBytes(strValue));
              break;
            case decimal decValue:
              bytes.Add(BitConverter.GetBytes(decimal.ToDouble(decValue)));
              break;
            case DateTime dateTimeValue:
              bytes.Add(BitConverter.GetBytes(dateTimeValue.Ticks));
              break;
            case TypeCode typeCode:
              bytes.Add(BitConverter.GetBytes((int)typeCode));
              break;
            case IBitConvertable bitConvertable:
              bytes.Add(bitConvertable.ObjectToBytes());
              break;
            case EntityBase<Guid> refGuid:
              bytes.Add(refGuid.Id.ToByteArray());
              break;
            case EntityBase<int> refInt:
              bytes.Add(BitConverter.GetBytes(refInt.Id));
              break;
            case EntityBase<string> refStr:
              bytes.Add(Encoding.Unicode.GetBytes(refStr.Id));
              break;
            default:
              var type = thisValues.Current.GetType();
              if (type.IsEnum)
                bytes.Add(BitConverter.GetBytes((long)thisValues.Current));
              else
                throw new ApplicationException($"Cannot convert {thisValues.Current.GetType().Name} '{thisValues.Current}' to byte array.");
              break;
          }
        }
      }
      return bytes.SelectMany(a => a).ToArray();
    }
    #endregion

    #region Equals

    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != GetType())
      {
        return false;
      }

      var other = (ValueObject)obj;
      using (IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator(),
        otherValues = other.GetAtomicValues().GetEnumerator())
      {
        while (thisValues.MoveNext() && otherValues.MoveNext())
        {
          if (thisValues.Current is null ^ otherValues.Current is null)
          {
            return false;
          }

          if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
          {
            return false;
          }
        }

        return !thisValues.MoveNext() && !otherValues.MoveNext();
      }
    }

    public override int GetHashCode()
    {
      return GetAtomicValues()
        .Select(x => x != null ? x.GetHashCode() : 0)
        .Aggregate((x, y) => x ^ y);
    }


    public static bool operator ==(ValueObject left, ValueObject right) => EqualOperator(left, right);
    public static bool operator !=(ValueObject left, ValueObject right) => NotEqualOperator(left, right);


    protected static bool EqualOperator(ValueObject left, ValueObject right)
    {
      if (left is null ^ right is null)
      {
        return false;
      }

      return left is null || left.Equals(right);
    }

    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
      return !(EqualOperator(left, right));
    }

    #endregion

  }
}