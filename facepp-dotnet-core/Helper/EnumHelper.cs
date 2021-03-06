﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cody.FacePP.Core
{
    public static class EnumHelper
    {
        public static Dictionary<int, string> ToDictionary(this Type _enumType)
        {
            if (!_enumType.IsEnum)
                throw new InvalidCastException("Only support enum type!");
            var dic = new Dictionary<int, string>();

            var ps = _enumType.GetFields();
            foreach (var p in ps)
            {
                if (p.FieldType != _enumType)
                    continue;

                var at = p.GetCustomAttribute(typeof(EnumDescriptionAttribute));
                if (at != null)
                {
                    var a = at as EnumDescriptionAttribute;
                    dic.Add(Convert.ToInt32(p.GetValue(_enumType)), a.Text);
                }
                else
                {
                    dic.Add(Convert.ToInt32(p.GetValue(_enumType)), p.Name);
                }
            }

            return dic;
        }

        public static Dictionary<int, ColorDescriptionAttribute> ToColorDictionary(this Type _enumType)
        {
            if (!_enumType.IsEnum)
                throw new InvalidCastException("Only support enum type!");
            var dic = new Dictionary<int, ColorDescriptionAttribute>();

            var ps = _enumType.GetFields();
            foreach (var p in ps)
            {
                if (p.FieldType != _enumType)
                    continue;

                var at = p.GetCustomAttribute(typeof(ColorDescriptionAttribute));
                if (at != null)
                {
                    var a = at as ColorDescriptionAttribute;
                    dic.Add(Convert.ToInt32(p.GetValue(_enumType)), a);
                }
            }

            return dic;
        }
    }
}