using System;

namespace Kiuss.Domain.Shared.Model
{
  /// <summary>
  /// Лог
  /// </summary>
  public class LogItem : EntityBase<Guid>
  {
    #region Конструкторы
    private LogItem() { }
    #endregion

    #region Свойства класса
    /// <summary>
    /// Доменная учетная запись
    /// </summary>
    public string LoginName { get; private set; }
    /// <summary>
    /// Учетная запись КИУСС
    /// </summary>
    public string UserName { get; private set; }
    /// <summary>
    /// ip адрес
    /// </summary>
    public string Ip { get; private set; }
    /// <summary>
    /// информация о браузере
    /// </summary>
    public string Browser { get; private set; }
    /// <summary>
    /// метка времени запроса
    /// </summary>
    public DateTime RequestDateTime { get; private set; }
    /// <summary>
    /// Длительность формирования ответа
    /// </summary>
    public long ResponseDurration { get; private set; } // Милисекунды
    /// <summary>
    /// Статус ответ
    /// </summary>
    public int StatusCode { get; private set; }
    /// <summary>
    /// тип метода запроса
    /// </summary>
    public string Method { get; private set; }
    /// <summary>
    /// Путь к ресурсу
    /// </summary>
    public string Path { get; private set; }
    /// <summary>
    /// Параметры запроса
    /// </summary>
    public string QueryString { get; private set; }
    /// <summary>
    /// Тело запроса
    /// </summary>
    public string RequestBody { get; private set; }
    /// <summary>
    /// Тела ответа
    /// </summary>
    public string ResponseBody { get; private set; }

    /// <summary>
    /// запрос в формате JSON
    /// </summary>
    public string RequestJSON { get; private set; }
    /// <summary>
    /// Ответ в формате JSON
    /// </summary>
    public string ResponseJSON { get; private set; }

		/// <summary>
		///текстовое сообщения
		/// </summary>
		public string MessageText { get; private set; }
		/// <summary>
		/// Статус сообщения
		/// </summary>
		public int MessageStatus { get; private set; }
		/// <summary>
		/// доп. информация
		/// </summary>
		public string MessageData { get; private set; }
		#endregion

		#region Статические методы класса
		/// <summary>
		/// Информация о запросах
		/// </summary>
		/// <param name="logMessage">Сообщение для записи</param>
		/// <returns></returns>
		public static LogItem New(LogMessage logMessage)
    {
      return new LogItem()
      {
        LoginName = logMessage.LoginName,
        UserName = logMessage.UserName,
        Ip = logMessage.Ip,
        Browser = logMessage.Browser,
        RequestDateTime = logMessage.RequestDateTime,
        ResponseDurration = logMessage.ResponseDurration,
        StatusCode = logMessage.StatusCode,
        Method = logMessage.Method,
        Path = logMessage.Path,
        QueryString = logMessage.QueryString,
        RequestBody = logMessage.RequestBody,
        ResponseBody = logMessage.ResponseBody,
        RequestJSON = logMessage.RequestJSON,
        ResponseJSON = logMessage.ResponseJSON,

				MessageText = logMessage.MessageText,
				MessageStatus = logMessage.MessageStatus,
				MessageData = logMessage.MessageData
			};
    }
		#endregion

		#region Внутрение типы
		public class LogMessage
		{
			/// <summary>
			/// Доменная учетная запись
			/// </summary>
			public string LoginName { get; set; }
			/// <summary>
			/// Учетная запись КИУСС
			/// </summary>
			public string UserName { get; set; }
			/// <summary>
			/// ip адрес
			/// </summary>
			public string Ip { get; set; }
			/// <summary>
			/// информация о браузере
			/// </summary>
			public string Browser { get; set; }
			/// <summary>
			/// метка времени запроса
			/// </summary>
			public DateTime RequestDateTime { get; set; }
			/// <summary>
			/// Длительность формирования ответа
			/// </summary>
			public long ResponseDurration { get; set; } // Милисекунды
			/// <summary>
			/// Статус ответ
			/// </summary>
			public int StatusCode { get; set; }
			/// <summary>
			/// тип метода запроса
			/// </summary>
			public string Method { get; set; }
			/// <summary>
			/// Путь к ресурсу
			/// </summary>
			public string Path { get; set; }
			/// <summary>
			/// Параметры запроса
			/// </summary>
			public string QueryString { get; set; }
			/// <summary>
			/// Тело запроса
			/// </summary>
			public string RequestBody { get; set; }
			/// <summary>
			/// Тела ответа
			/// </summary>
			public string ResponseBody { get; set; }

			/// <summary>
			/// запрос в формате JSON
			/// </summary>
			public string RequestJSON { get; set; }
			/// <summary>
			/// Ответ в формате JSON
			/// </summary>
			public string ResponseJSON { get; set; }

			/// <summary>
			/// текстовое сообщение
			/// </summary>
			public string MessageText { get; set; }
			/// <summary>
			/// Статус
			/// </summary>
			public int MessageStatus { get; set; }
			/// <summary>
			/// текстовое сообщение
			/// </summary>
			public string MessageData { get; set; }

		}
		#endregion

	}
}