using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VedSoft.Utility.APIHandler
{
    public class APIHandlerService
    {

    public static T PostAPICall<T>(string url, object value)
    {
        T resultView;

        using (var client = new ExtendedWebClient())
        {
                client.Headers.Add(System.Net.HttpRequestHeader.KeepAlive, "true");
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new DecimalJsonConverter());
            settings.Formatting = Formatting.Indented;


            var json = JsonConvert.SerializeObject(value, settings);

            string result = client.UploadString(url, json);
            resultView = JsonConvert.DeserializeObject<T>(result, settings);
            //  resultView = deserializer.Deserialize<T>(result);  
        }

        return resultView;
    }
    public static T PostAPICallIgnorePostDecimalZero<T>(string url, object value)
    {
        T resultView;
        using (var client = new ExtendedWebClient())
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.Converters.Add(new DecimalJsonConverter());
            settings.Formatting = Formatting.Indented;
            var json = JsonConvert.SerializeObject(value, settings);
            string result = client.UploadString(url, json);
            resultView = JsonConvert.DeserializeObject<T>(result, settings);
        }
        return resultView;
    }
    public static T GetAPICall<T>(string url)
    {

        T resultView;
        using (var client = new ExtendedWebClient())
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new DecimalJsonConverter());
            settings.Formatting = Formatting.Indented;

            string result = client.DownloadString(url);
            resultView = JsonConvert.DeserializeObject<T>(result, settings);
        }
        return resultView;
    }
    public static T GetJson<T>(string jsonString)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.Converters.Add(new DecimalJsonConverter());
        settings.Formatting = Formatting.Indented;
        return JsonConvert.DeserializeObject<T>(jsonString, settings);
    }
    public static string GetSerializerObj(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
    public static T DeserializeObject<T>(string jsonString)
    {

        T resultView;
        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.Converters.Add(new DecimalJsonConverter());
        settings.Formatting = Formatting.Indented;
        resultView = JsonConvert.DeserializeObject<T>(jsonString, settings);
        return resultView;
    }
}
    class DecimalJsonConverter : JsonConverter
    {
        public DecimalJsonConverter()
        {
        }

        public override bool CanRead
        {
            get
            {
                return false;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(decimal) || objectType == typeof(Nullable<decimal>) || objectType == typeof(float) || objectType == typeof(double));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (IsWholeValue(value))
            {
                writer.WriteRawValue(JsonConvert.ToString(Convert.ToInt64(value)));
            }
            else
            {
                writer.WriteRawValue(JsonConvert.ToString(value));
            }
        }


        private static bool IsWholeValue(object value)
        {
            if (value is Nullable)
            {
                return false;
            }
            else if (value is decimal || value is Nullable<decimal>)
            {
                decimal decimalValue = (decimal)value;
                return decimalValue == Math.Truncate(decimalValue);
            }
            else if (value is float || value is double)
            {
                double doubleValue = (double)value;
                return doubleValue == Math.Truncate(doubleValue);
            }

            return false;
        }
    }
}
