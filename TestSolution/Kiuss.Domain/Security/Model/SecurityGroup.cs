﻿namespace Kiuss.Domain.Security.Model
{
  public class SecurityGroup : SecuritySubject
  {
    private SecurityGroup(string id) : base(id) { }
    /*
    --------    -------------------------------------   -----------------------------------------------------
    REM_OBJ     Технологический объект                  Доступ к данным удаленного технологического объекта
    00_SYS      ОАО "НК "РОСНЕФТЬ"	                    Доступ к системным данным
    01_DO       ОАО "НК "РОСНЕФТЬ"                      Доступны данные по всей Компании
    02_DO       ООО "РН - ЮГАНСКНЕФТЕГАЗ"
    03_DO       ОАО "ТОМСКНЕФТЬ" ВНК
    04_DO       ООО "РН - ПУРНЕФТЕГАЗ"
    05_DO       ОАО "САМАРАНЕФТЕГАЗ"
    06_DO       ОАО "УДМУРТНЕФТЬ"
    07_DO       ООО  "РН - СЕВЕРНАЯ НЕФТЬ"
    08_DO       ООО "РН - САХАЛИНМОРНЕФТЕГАЗ"
    09_DO       ООО "РН - КРАСНОДАРНЕФТЕГАЗ"
    10_DO       ООО "РН - СТАВРОПОЛЬНЕФТЕГАЗ"
    11_DO       ЗАО "ВАНКОРНЕФТЬ"
    12_DO       ОАО "ВОСТСИБНЕФТЕГАЗ"
    13_DO       ЗАО "РОСПАН ИНТЕРНЕШНЛ"
    14_DO       ОАО "ОРЕНБУРГНЕФТЬ"
    15_DO       ОАО "ВАРЬЁГАННЕФТЕГАЗ"
    16_DO       ОАО "ВЕРХНЕЧОНСКНЕФТЕГАЗ"
    17_DO       ОАО "САМОТЛОРНЕФТЕГАЗ"
    18_DO       ОАО "РН - НЯГАНЬНЕФТЕГАЗ"
    19_DO       ООО "РН - УВАТНЕФТЕГАЗ"
    20_DO       Филиал ОАО «РН Менеджмент» «Центр экспертной поддержки и технического развития БН РиД»
    21_DO       ООО "САМАРАНИПИНЕФТЬ"
    22_DO       ООО "РН - КРАСНОЯРСКНИПИНЕФТЬ"
    23_DO       ООО "РОСНЕФТЬ - НТЦ"
    24_DO       ООО "РН - САХАЛИННИПИНЕФТЬ"
    25_DO       ООО "УФАНИПИНЕФТЬ"
    26_DO       ОАО "ГРОЗНЕФТЕГАЗ"
    27_DO       ОАО "НК "РОСНЕФТЬ"-ДАГНЕФТЬ"
    28_DO       ОАО "ДАГНЕФТЕГАЗ"
    29_DO       ООО "КОМПАНИЯ "ПОЛЯРНОЕ СИЯНИЕ"
    30_DO       ООО "ВОСТОК-ЭНЕРДЖИ"
    31_DO       ДОСТУП К ДАННЫМООО "РН-ЭКСПЛОРЕЙШН"
    32_DO       ЗАО "РН-ШЕЛЬФ-ДАЛЬНИЙ ВОСТОК"
    33_DO       ОАО "РН-НИЖНЕВАРТОВСК"
    34_DO       ОАО "ТЮМЕННЕФТЕГАЗ"
    35_DO       ООО "БУГУРУСЛАННЕФТЬ"
    36_DO       ОАО "СУЗУН"
    37_DO       ООО "ТАГУЛЬСКОЕ"
    38_DO       ООО "РН-КАСПМОР"
    39_DO       ОАО "ЕРМАКОВСКОЕ"
    40_DO       ОАО "НИЖНЕВАРТОВСКОЕ НЕФТЕГАЗОДОБЫВАЮЩЕЕ ПРЕДПРИЯТИЕ"
    41_DO       ООО "СЕВЕРО-ВАРЬЕГАНСКОЕ"
    42_DO       ООО "СП "ВАНЬЕГАННЕФТЬ"
    43_DO       ООО "ЗАПАДНО-НИКОЛЬСКОЕ"
    44_DO       ООО "ТААС-ЮРЯХ-НЕФТЕГАЗДОБЫЧА"
    45_DO       ООО "СЛАВНЕФТЬ-КРАСНОЯРСКНЕФТЕГАЗ"
    46_DO       ОАО "СЛАВНЕФТЬ-МЕГИОННЕФТЕГАЗ"
    47_DO       САХАЛИН-1
    48_DO       ОАО "РН "ИНГНЕФТЬ"
    49_DO       ООО "ГУБЕРНСКАЯ РЕСУРСНАЯ КОМПАНИЯ"
    50_DO       ОАО "КОРПОРАЦИЯ ЮГРАНЕФТЬ"
    51_DO       ООО "СЛОБОДСКОЕ"
    52_DO       ООО "ЮПИТЕР-А"
    53_DO       ОАО "РУССКО-РЕЧЕНСКОЕ"
    54_DO       ЗАО "МЕССОЯХАНЕФТЕГАЗ"
    55_DO       ООО "КЫНСКО-ЧАСЕЛЬСКОЕ НЕФТЕГАЗ"
    56_DO       ОАО "БРАТСКЭКОГАЗ"
    57_DO       БЛОК 21
    58_DO       ЗАО "ПУРГАЗ"
    59_DO       ОАО "СИБНЕФТЕГАЗ"
    60_DO       ООО "НГК "ИТЕРА"
    61_DO       ООО "РН-ШЕЛЬФ-АРКТИКА
    62_DO       ООО "СЕВЕРО-ДЕМЬЯНСКОЕ"
    63_DO       ООО "ПОЛУНЬЯХСКОЕ"
    64_DO       ООО "КАЛЬЧИНСКОЕ"
    65_DO       ЛОДОЧНОЕ
    66_DO       СП "КАРМОРНЕФТЕГАЗ"
    67_DO       ООО "ИНЗЕРНЕФТЬ"
    68_DO       ООО "РН ЭКСПЛОРЭЙШН"
    */
    public static SecurityGroup New(string id) => new SecurityGroup(id)
    {
      Type = SecuritySubjectType.Group,
    };
  }
}