﻿using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json.Serialization;

namespace JCSoft.WX.Framework.Models.Requests
{
    public abstract class RequestMessage : WXMessage
    {
        public RequestMessage() { }

        public RequestMessage(XElement xml)
        {
            this.FromUserName = xml.Element("FromUserName").GetValue();
            this.ToUserName = xml.Element("ToUserName").GetValue();
            this.CreateTime = Int64.Parse(xml.Element("CreateTime").GetValue());
            this.MsgId = xml.Element("MsgId") != null ? Int64.Parse(xml.Element("MsgId").GetValue()) : 0;
        }

        public static T Deserializ<T>(Stream stream)
            where T : RequestMessage
        {
            var xs = new XmlSerializer(typeof(T));
            return (T)xs.Deserialize(stream);
        }

        [XmlElement("MsgId")]
        public long MsgId { get; set; }
    }
}
