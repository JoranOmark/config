﻿using System;
using System.Collections.Generic;

namespace Config.Net.TypeParsers
{
   class BoolParser : ITypeParser
   {
      private static readonly Dictionary<string, bool> AllowedValues =
         new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase)
            {
               {"true", true},
               {"yes", true},
               {"1", true},
               {"false", false},
               {"no", false},
               {"0", false}
            };

      public IEnumerable<Type> SupportedTypes => new[] { typeof(bool) };

      public bool TryParse(string value, Type t, out object result)
      {
         if (value == null || !AllowedValues.ContainsKey(value))
         {
            result = default(bool);
            return false;
         }

         result = AllowedValues[value];
         return true;
      }

      /// <summary>
      /// This method returns to basic bool to string conversion where the output string is in lower cases.
      /// Currently we have no way of identifying string values which are parsed in TryParse method so we
      /// can only return true/false from ToRawString method.
      /// </summary>
      /// <param name="value">Non-Nullable bool value</param>
      /// <returns>String equivalent of boolean in lower case. eg. true/false</returns>
      public string ToRawString(object value)
      {
         return value.ToString().ToLowerInvariant();
      }
   }
}
