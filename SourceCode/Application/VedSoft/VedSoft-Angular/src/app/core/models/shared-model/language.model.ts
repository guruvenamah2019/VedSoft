import { LanguageEnum } from '../../enums/language.enum';

type seprator = "." | "," | " ";
export const SepratorEnum = {
    COMMA: "," as seprator,
    DOT: '.' as seprator,
    SPACE: " " as seprator
}

type langaugeCode = "en-us" | "es-mx" | "pt-br" | "fr-fr" | "ru-ru" | 'zh-cn' | 'cs-cz' | 'de-de' | 'en-gb' | 'mk-mk' | 'ja-jp';
export const LanguageCodeEnum = {
    ENGLISH: "en-us" as langaugeCode,
    PORTUGUESE: 'pt-br' as langaugeCode,
    SPANISH: 'es-mx' as langaugeCode,
    FRENCH: 'fr-fr' as langaugeCode,
    RUSSIAN: 'ru-ru' as langaugeCode,
    CHINESE: 'zh-cn' as langaugeCode,
    CZECH: 'cs-cz' as langaugeCode,
    GERMAN: 'de-de' as langaugeCode,
    ENGLISH_UK: 'en-gb' as langaugeCode,
    MACIDONAIN: 'mk-mk' as langaugeCode,
    JAPANESE: 'ja-jp' as langaugeCode,
}
type dateFormat = "MM/DD/YYYY" | "D/M/YYYY" | "D.M.YYYY" | "YYYY.M.D" | "M/D/YYYY"  ;
export const DateFormatConst = {
    M_D: "M/D/YYYY" as dateFormat,
    MM_DD: "M/D/YYYY" as dateFormat,
    DD_MM: 'D/M/YYYY' as dateFormat,
    DDMM: 'D.M.YYYY' as dateFormat,
    YYMM: 'YYYY.M.D' as dateFormat,
}

export interface LanguageModel {
    ID?: LanguageEnum,
    Name?: string,
    Code?: langaugeCode,
    DecimalSeprator?: seprator,
    ThousandSeprator?: seprator,
    DateFormat?: dateFormat
}

export const LanguageMapping: LanguageModel[] =
    [
        {
            Code: LanguageCodeEnum.ENGLISH,
            ID: LanguageEnum.ENGLISH,
            Name: "ENGLISH",
            DecimalSeprator: ".",
            ThousandSeprator: ",",
            DateFormat: DateFormatConst.M_D
        },
        {
            Code: LanguageCodeEnum.SPANISH,
            ID: LanguageEnum.SPANISH,
            Name: "SPANISH",
            DecimalSeprator: ".",
            ThousandSeprator: ",",
            DateFormat: DateFormatConst.DD_MM
        },
        {
            Code: LanguageCodeEnum.GERMAN,
            ID: 3,
            Name: "GERMAN",
            DecimalSeprator: ",",
            ThousandSeprator: ".",
            DateFormat: DateFormatConst.DD_MM
        },
        {
            Code: LanguageCodeEnum.FRENCH,
            ID: 4,
            Name: "FRENCH",
            DecimalSeprator: ".",
            ThousandSeprator: ",",
            DateFormat: DateFormatConst.DD_MM
        },
        {
            Code: LanguageCodeEnum.PORTUGUESE,
            ID: 5,
            Name: "PORTUGUESE",
            DecimalSeprator: ",",
            ThousandSeprator: ".",
            DateFormat: DateFormatConst.DD_MM
        },
        {
            Code: LanguageCodeEnum.CHINESE,
            ID: 6,
            Name: "CHINESE",
            DecimalSeprator: ".",
            ThousandSeprator: ",",
            DateFormat: DateFormatConst.YYMM
        },

        {
            Code: LanguageCodeEnum.RUSSIAN,
            ID: 7,
            Name: "RUSSIAN",
            DecimalSeprator: ",",
            ThousandSeprator: ".",
            DateFormat: DateFormatConst.MM_DD
        },
        {
            Code: LanguageCodeEnum.MACIDONAIN,
            ID: 8,
            Name: "MACIDONAIN",
            DecimalSeprator: ".",
            ThousandSeprator: ",",
            DateFormat: DateFormatConst.MM_DD
        },
        {
            Code: LanguageCodeEnum.CZECH,
            ID: 9,
            Name: "CZECH",
            DecimalSeprator: ",",
            ThousandSeprator: ".",
            DateFormat: DateFormatConst.MM_DD
        },
        {
            Code: LanguageCodeEnum.JAPANESE,
            ID: 10,
            Name: "JAPANESE",
            DecimalSeprator: ".",
            ThousandSeprator: ",",
            DateFormat: DateFormatConst.MM_DD
        }, {
            Code: LanguageCodeEnum.ENGLISH_UK,
            ID: 11,
            Name: "ENGLISH_UK",
            DecimalSeprator: ".",
            ThousandSeprator: ",",
            DateFormat: DateFormatConst.DD_MM
        }
    ];


