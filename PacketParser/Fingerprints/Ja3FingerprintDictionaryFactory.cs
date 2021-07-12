﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PacketParser.Fingerprints
{
    class Ja3FingerprintDictionaryFactory {

        //{"desc":"Adium 1.5.10 (a)","ja3_hash":"93948924e733e9df15a3bb44404cd909","ja3_str":"769,255-49188-49187-49162-49161-49160-49192-49191-49172-49171-49170-49190-49189-49157-49156-49155-49194-49193-49167-49166-49165-107-103-57-51-22-61-60-53-47-10-49159-49169-49154-49164-5,0-10-11-13,23-24-25,0"}
        public static Dictionary<string, string> CreateDictionary(string jsonDictionary) {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach(string line in System.IO.File.ReadLines(jsonDictionary)) {
                System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(line, "\"desc\":\"(?<desc>[^\"]*)\",\"ja3_hash\":\"(?<hash>[^\"]*)\"");
                if (match.Success) {
                    string hash = match.Groups["hash"].Value;
                    if (!dict.ContainsKey(hash))
                        dict.Add(hash, match.Groups["desc"].Value);
                }
            }
            return dict;
        }
    }
}
