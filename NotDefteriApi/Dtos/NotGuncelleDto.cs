﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotDefteriApi.Dtos
{
    public class NotGuncelleDto
    {
        public int NotId { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
    }
}