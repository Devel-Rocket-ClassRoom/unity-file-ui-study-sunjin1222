//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System;

//using UnityEngine;

//public class Vector3Converter : JsonConverter<Vector3>
//{
//    public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
//    {
//        Vector3 v = Vector3.zero;

//        JObject jOb = JObject.Load(reader);
//        v.x = (float)jOb["X"];
//        v.y = (float)jOb["Y"];
//        v.z = (float)jOb["Z"];
//        return v;

//    }

//    public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
//    {
//        writer.WriteStartObject();
//        writer.WritePropertyName("X");
//        writer.WriteValue(value.x);
//        writer.WritePropertyName("Y");
//        writer.WriteValue(value.y);
//        writer.WritePropertyName("Z");
//        writer.WriteValue(value.z);
//        writer.WriteEndObject();

//    }
//}

//public class QuaternionConverter : JsonConverter<Quaternion>
//{
//    public override Quaternion ReadJson(JsonReader reader, Type objectType, Quaternion existingValue, bool hasExistingValue, JsonSerializer serializer)
//    {
//        Quaternion v = Quaternion.identity;

//        JObject jOb = JObject.Load(reader);
//        v.x = (float)jOb["X"];
//        v.y = (float)jOb["Y"];
//        v.z = (float)jOb["Z"];
//        return v;

//    }


//    public override void WriteJson(JsonWriter writer, Quaternion value, JsonSerializer serializer)
//    {
//        writer.WriteStartObject();
//        writer.WritePropertyName("X");
//        writer.WriteValue(value.x);
//        writer.WritePropertyName("Y");
//        writer.WriteValue(value.y);
//        writer.WritePropertyName("Z");
//        writer.WriteValue(value.z);
//        writer.WriteEndObject();

//    }


//}
//public class ColorConverter : JsonConverter<Color>
//{
//    public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
//    {
//        Color v = Color.coral;

//        JObject jOb = JObject.Load(reader);
//        v.r = (float)jOb["R"];
//        v.g = (float)jOb["G"];
//        v.b = (float)jOb["B"];
//        v.r = (float)jOb["A"];
//        return v;

//    }




//    public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
//    {
//        writer.WriteStartObject();
//        writer.WritePropertyName("R");
//        writer.WriteValue(value.r);
//        writer.WritePropertyName("G");
//        writer.WriteValue(value.g);
//        writer.WritePropertyName("B");
//        writer.WriteValue(value.b);
//        writer.WritePropertyName("A");
//        writer.WriteValue(value.r);
//        writer.WriteEndObject();

//    }
//}

