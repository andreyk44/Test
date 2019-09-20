using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kiuss.Domain.Shared.Model
{
  /// <summary>
  /// Единица изменения.
  /// </summary>
  /// <remarks>
  /// Символы степени:
  ///   ³ - Alt+0179(Num) 
  ///   ² - Alt+0178(Num)
  /// </remarks>
  [Owned]
  public class UnitOfMeasure : ValueObject
  {
    public const int MaxLength = 12;

    /// <summary>
    /// Количество ячеек на линейный дюйм.
    /// </summary>
    public static UnitOfMeasure Mesh => New("меш");

    /// <summary>
    /// Грузоподъёмность в тонно-силах.
    /// </summary>
    public static UnitOfMeasure CarryingCapacityTf => New("тс");

    /// <summary>
    /// Грузоподъёмность в тоннах.
    /// </summary>
    public static UnitOfMeasure CarryingCapacityT => New("т");

    /// <summary>
    /// Длина в метрах.
    /// </summary>
    public static UnitOfMeasure Length => New("м");

    /// <summary>
    /// Длина в миллиметрах.
    /// </summary>
    public static UnitOfMeasure LengthSmall => New("мм");

    /// <summary>
    /// Длина в дюймах.
    /// </summary>
    public static UnitOfMeasure LengthSmallInch => New("дюйм");

    /// <summary>
    /// Разрывное усилие в килоньютонах.
    /// </summary>
    public static UnitOfMeasure BreakingStrength => New("кН");

    /// <summary>
    /// Мощность в киловаттах.
    /// </summary>
    public static UnitOfMeasure Power => New("кВт");

    /// <summary>
    /// Глубина в метрах.
    /// </summary>
    public static UnitOfMeasure Depth => New("м");

    /// <summary>
    /// Высота в метрах.
    /// </summary>
    public static UnitOfMeasure Height => New("м");

    /// <summary>
    /// Нагрузка в тонно-силах.
    /// </summary>
    public static UnitOfMeasure LoadTF => New("тс");

    /// <summary>
    /// Нагрузка в тоннах.
    /// </summary>
    public static UnitOfMeasure LoadT => New("т");

    /// <summary>
    /// Вес в тоннах.
    /// </summary>
    public static UnitOfMeasure Weight => New("т");

    /// <summary>
    /// Вес в кг.
    /// </summary>
    public static UnitOfMeasure WeightSmall => New("кг");

    /// <summary>
    /// Крутящий момент в килоньютон-метрах.
    /// </summary>
    public static UnitOfMeasure Torque => New("кН*м");

    /// <summary>
    /// Частота вращения в оборотах/минуту.
    /// </summary>
    public static UnitOfMeasure RotationalSpeed => New("об/мин");

    /// <summary>
    /// Давление в иегапаскалях.
    /// </summary>
    public static UnitOfMeasure Pressure => New("МПа");

    /// <summary>
    /// Плановая наработка талевого каната в тонно-километрах.
    /// </summary>
    public static UnitOfMeasure OperatingResource => New("т/км");

    /// <summary>
    /// Водоизмещение в тоннах.
    /// </summary>
    public static UnitOfMeasure Displacement => New("т");

    /// <summary>
    /// Температура в градусах Цельсия.
    /// </summary>
    public static UnitOfMeasure Temperature => New("°C");

    /// <summary>
    /// Количество / Вместимость в штуках.
    /// </summary>
    public static UnitOfMeasure Pieces => New("шт");

    /// <summary>
    /// Количество ходов насоса в ходах/минуту.
    /// </summary>
    public static UnitOfMeasure NumberOfStrikes => New("ход/мин");

    /// <summary>
    /// Объём в кубометрах.
    /// </summary>
    public static UnitOfMeasure Volume => New("м³");


    /// <summary>
    /// Пропускная способность в кубометрах/час.
    /// </summary>
    public static UnitOfMeasure ThroughputCapacityVolume => New("м³/ч");

    /// <summary>
    /// Пропускная способность в килограммах/час.
    /// </summary>
    public static UnitOfMeasure ThroughputCapacityWeight => New("кг/ч");

    /// <summary>
    /// Центробежная сила в единицах G.
    /// </summary>
    public static UnitOfMeasure GForce => New("G");

    public static UnitOfMeasure Persons => New("чел");
    public static UnitOfMeasure Sacks => New("меш");


    #region Meteo Page

    /// <summary>
    /// Давление в мм. рт ст. 
    /// </summary>
    public static UnitOfMeasure BarometricPressure => New("мм. рт. ст.");

    /// <summary>
    /// Скорость в метрах в секунду
    /// </summary>
    public static UnitOfMeasure Speed => New("м/с");

    /// <summary>
    /// Интервал, период в секундах
    /// </summary>
    public static UnitOfMeasure Second => New("сек");

    /// <summary>
    /// Интервал, период в часах
    /// </summary>
    public static UnitOfMeasure Hour => New("ч");

    #endregion

    #region Drill Mud Page

    /// <summary>
    /// Плотность
    /// </summary>
    public static UnitOfMeasure Density => New("г/см³");

    /// <summary>
    /// Условная вязкость
    /// </summary>
    public static UnitOfMeasure RelativeViscosity => New("с");

    /// <summary>
    /// Динамическая вязкость
    /// </summary>
    public static UnitOfMeasure Centipoise => New("сП");

    /// <summary>
    /// Деципаскаль
    /// </summary>
    public static UnitOfMeasure Decipascal => New("дПа");

    /// <summary>
    /// Фильтрация
    /// </summary>
    public static UnitOfMeasure Filtration => New("см³/30мин");

    /// <summary>
    /// Мгновенная фильтрация
    /// </summary>
    public static UnitOfMeasure InstantFiltering => New("см³/30с");

    /// <summary>
    /// Толщина в миллиметрах
    /// </summary>
    public static UnitOfMeasure ThicknesSmal => New("мм");

    /// <summary>
    ///  Объемное содержание
    /// </summary>
    public static UnitOfMeasure Percent => New("%");

    /// <summary>
    ///  Катионообменная емкость
    /// </summary>
    public static UnitOfMeasure CationExchangeCapacity => New("кг/м³");

    /// <summary>
    ///  Жесткость
    /// </summary>
    public static UnitOfMeasure Rigidity => New("мг/л");

    /// <summary>
    ///  Содержание ионов
    /// </summary>
    public static UnitOfMeasure IonContent => New("мг/л");

    /// <summary>
    ///  Содержание вещества
    /// </summary>
    public static UnitOfMeasure SubstanceContent => New("кг/м³");

    /// <summary>
    ///  Избыток вещества
    /// </summary>
    public static UnitOfMeasure ExcessSubstance => New("кг/м³");

    /// <summary>
    ///  Удельное сопротивление
    /// </summary>
    public static UnitOfMeasure Resistivity => New("Ом*м");

    /// <summary>
    ///  Электростабильность
    /// </summary>
    public static UnitOfMeasure Electrostability => New("В");

    /// <summary>
    ///  Единица мутности
    /// </summary>
    public static UnitOfMeasure TurbidityUnit => New("ЕМ/литр");

    /// <summary>
    ///  Без единицы измерения
    /// </summary>
    public static UnitOfMeasure WithoutUnit => New("");

    #endregion

    #region RockCuttingTool

    /// <summary>
    /// Диаметр в мм. 
    /// </summary>
    public static UnitOfMeasure Diameter => New("мм");

    /// <summary>
    /// Проходка в м. 
    /// </summary>
    public static UnitOfMeasure Penetration => New("м");

    /// <summary>
    /// Пространственная интенсивность в град/10м. 
    /// </summary>
    public static UnitOfMeasure SpatialIntensity => New("град/10м");

    /// <summary>
    /// Удельная гидравлическая мощность в л.с./дюйм². 
    /// </summary>
    public static UnitOfMeasure SpecificHydraulicPower => New("л.с./дюйм²");

    /// <summary>
    /// Нагрузка на долото в т. 
    /// </summary>
    public static UnitOfMeasure ChiselLoad => New("т");

    /// <summary>
    /// Монофазный силовой потенциал в м/ч. 
    /// </summary>
    public static UnitOfMeasure MonophasicPowerPotential => New("м/ч");

    /// <summary>
    /// Расход в л/с. 
    /// </summary>
    public static UnitOfMeasure Consumption => New("л/с");

    /// <summary>
    /// Давление в атмосферах.
    /// </summary>
    public static UnitOfMeasure BottomPressure => New("атм");

    /// <summary>
    /// Дифференциальный перепад в атм. 
    /// </summary>
    public static UnitOfMeasure DifferentialDifferential => New("атм");

    /// <summary>
    /// Обороты долота в тыс.об. 
    /// </summary>
    public static UnitOfMeasure BitTurns => New("тыс.об");

    /// <summary>
    /// Уровень стола ротора в м. 
    /// </summary>
    public static UnitOfMeasure RotorTableLevel => New("м");

    #endregion

    #region Cleaning System

    /// <summary>
    /// Коэффициент влажности шлама (м³/м³)
    /// </summary>
    public static UnitOfMeasure SludgeMoistureRatio => New("м³/м³");

    /// <summary>
    /// Давление на входе (атм)
    /// </summary>
    public static UnitOfMeasure InletPressure => New("атм");

    /// <summary>
    /// Плотность в системе измерения СИ (т/м³)
    /// </summary>
    public static UnitOfMeasure DensitySI => New("т/м³");

    /// <summary>
    /// Разм./кол-во конусов (мм/шт)
    /// </summary>
    public static UnitOfMeasure SizeNumberOfCones => New("мм/шт");

    /// <summary>
    /// Подача насоса (л/мин)
    /// </summary>
    public static UnitOfMeasure PumpFeed => New("л/мин");

    /// <summary>
    /// Плотность раствора на входе (г/см³)
    /// </summary>
    public static UnitOfMeasure ProportionSolutionEntrance => New("г/см³");

    /// <summary>
    /// Плотность раствора на выходе (г/см³)
    /// </summary>
    public static UnitOfMeasure ProportionSolutionOutlet => New("г/см³");

    /// <summary>
    /// Плотность раствора пульпы  (г/см³)
    /// </summary>
    public static UnitOfMeasure ProportionSolutionPpulp => New("г/см³");

    /// <summary>
    /// Переработано раствора (м³)
    /// </summary>
    public static UnitOfMeasure RecycledSolution => New("м³");

    /// <summary>
    /// Объем фугата (м³)
    /// </summary>
    public static UnitOfMeasure FugateVolume => New("м³");

    #endregion

    #region BottomHoleAssembly.
    /// <summary>
    /// Градусы.
    /// </summary>
    public static UnitOfMeasure Degree => New("град");

    /// <summary>
    /// Количество оборотов на единицу расхода.
    /// </summary>
    public static UnitOfMeasure RotationPerFlow => New("об/л");

    /// <summary>
    /// Скорость передачи данных.
    /// </summary>
    public static UnitOfMeasure DataSpeed => New("бит/с");
    #endregion
    #region Cementation.
    /// <summary>
    /// м³/т.
    /// </summary>
    public static UnitOfMeasure CubicMeterPerTon => New("м³/т");
    #endregion

    private UnitOfMeasure()
    {

    }

    public string Code { get; private set; }

    public static UnitOfMeasure New(string uomCode)
    {
      if (uomCode != null && uomCode.Length > MaxLength)
        throw new ArgumentOutOfRangeException(nameof(uomCode), uomCode, $"Код единицы измерения превышает допустимую длину {MaxLength}");

      return new UnitOfMeasure { Code = uomCode ?? string.Empty };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return Code;
    }

    public override string ToString() => Code;
  }
}
