﻿using System.Xml.Serialization;

namespace Anathema.Rhonin.TrainingThree.XML.Entities
{
    //[XmlRoot("car")]
    public class EngineType //: Engine
    {
       
        [XmlText()]
        public string Silnik { get; set; }
    }
}