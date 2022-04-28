using I2.Loc;
using Il2CppSystem.Collections.Generic;
using System;
using System.Linq;
using System.Text.Json;

namespace Explorer.Framework.Localization
{
    // TODO: Decide and fix whether to use Il2CppSystem Types or System Types (List, Dictionaries etc.)
    public static class Localization
    {
        /// <summary>
        /// Returns every <see cref="I2.Loc.TermData"/> as typed Dictionary of <see cref="Dictionary{System.String, I2.Loc.TermData}"/>
        /// <para>
        /// TKey is <see cref="System.String"/>;
        /// </para>
        /// <para>
        /// TValue is <see cref="I2.Loc.TermData"/>;
        /// </para>
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, TermData> GetTermsDict()
        {
            return I2.Loc.LocalizationManager.Sources[0].mDictionary;
        }

        /// <summary>
        /// Returns every <see cref="I2.Loc.TermData"/> as a List of <see cref="List{I2.Loc.TermData}"/>
        /// </summary>
        /// <returns></returns>
        public static List<TermData> GetTerms()
        {
            return I2.Loc.LocalizationManager.Sources[0].mTerms;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termKey"></param>
        /// <returns></returns>
        public static TermData GetTermData(string termKey)
        {
            return I2.Loc.LocalizationManager.Sources[0].GetTermData(termKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static TermData GetTermDataAtIndex(int index)
        {
            return I2.Loc.LocalizationManager.Sources[0].mTerms[index];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termDataObject"></param>
        /// <returns></returns>
        public static int GetTermDataIndex(TermData termDataObject)
        {
            return I2.Loc.LocalizationManager.Sources[0].mTerms.IndexOf(termDataObject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="updateDictionary"></param>
        private static void DeleteTermDataAtIndex(int index, bool updateDictionary = true)
        {
            I2.Loc.LocalizationManager.Sources[0].mTerms.RemoveAt(index);
            if (updateDictionary)
            {
                UpdateDictionary();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="updateDictionary"></param>
        /// <returns></returns>
        public static bool DeleteTermData(string termKey, bool updateDictionary = true)
        {
            bool success = I2.Loc.LocalizationManager.Sources[0].mTerms.Remove(GetTermData(termKey));
            if (updateDictionary)
            {
                UpdateDictionary();
            }
            return success;
        }

        /// <summary>
        /// Deletes a <see cref="I2.Loc.TermData"/>
        /// </summary>
        /// <param name="index"></param>
        /// <param name="updateDictionary"></param>
        /// <returns></returns>
        public static bool DeleteTermData(int index, bool updateDictionary = true)
        {
            bool success = I2.Loc.LocalizationManager.Sources[0].mTerms.Remove(GetTermDataAtIndex(index));
            if (updateDictionary)
            {
                UpdateDictionary();
            }
            return success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toDelete"></param>
        /// <param name="updateDictionary"></param>
        /// <returns></returns>
        public static bool DeleteTermData(TermData toDelete, bool updateDictionary = true)
        {
            bool success = I2.Loc.LocalizationManager.Sources[0].mTerms.Remove(toDelete);
            if (updateDictionary)
            {
                UpdateDictionary();
            }
            return success;
        }

        /// <summary>
        /// Replaces a <see cref="I2.Loc.TermData"/>
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="newTermData"></param>
        // TODO: Maybe need to invoke UpdateDictionary() here too
        public static void ReplaceTermData(string termKey, TermData newTermData)
        {
            I2.Loc.LocalizationManager.Sources[0].mTerms[GetTermDataIndex(GetTermData(termKey))] = newTermData;
        }

        /// <summary>
        /// Replaces a <see cref="I2.Loc.TermData"/>
        /// </summary>
        /// <param name="oldTermData"></param>
        /// <param name="newTermData"></param>
        public static void ReplaceTermData(TermData oldTermData, TermData newTermData)
        {
            I2.Loc.LocalizationManager.Sources[0].mTerms[GetTermDataIndex(oldTermData)] = newTermData;
        }

        /// <summary>
        /// Replaces a <see cref="I2.Loc.TermData"/>
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newTermData"></param>
        public static void ReplaceTermData(int index, TermData newTermData)
        {
            I2.Loc.LocalizationManager.Sources[0].mTerms[index] = newTermData;
        }

        /// <summary>
        /// Adds a <see cref="I2.Loc.TermData"/>
        /// </summary>
        /// <param name="newTermData"></param>
        /// <param name="updateDictionary"></param>
        public static void AddTermData(TermData newTermData, bool updateDictionary = true)
        {
            I2.Loc.LocalizationManager.Sources[0].mTerms.Add(newTermData);
            if (updateDictionary)
            {
                UpdateDictionary();
            }
        }

        /// <summary>
        /// Adds an empty <see cref="I2.Loc.TermData"/>
        /// <para/>
        /// For testing purposes only. Do not use in mods!
        /// </summary>
        // never use this
        [Obsolete("This method is NOT TO BE USED! It is a test method.")]
        public static void AddTermEmpty()
        {
            AddTermData(new TermData());
        }

        /// <summary>
        /// Adds a <see cref="I2.Loc.TermData"/>
        /// </summary>
        /// <param name="termKey"></param>

        public static void AddTerm(string termKey)
        {
            AddTerm(termKey, description: null);
        }

        /// <summary>
        /// Adds a <see cref="I2.Loc.TermData"/>
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="description"></param>
        public static void AddTerm(string termKey, string description = null)
        {
            // can also pass TermType = 0 as it's an enum
            TermData termData = new TermData { Term = termKey, TermType = eTermType.Text, Description = description, Flags = new byte[GetLanguages().Count], Languages = Enumerable.Repeat("", GetLanguages().Count).ToList().ToArray() };
            AddTermData(termData);
        }

        /// <summary>
        /// Adds a <see cref="I2.Loc.TermData"/>
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="languageCode_Translation"></param>
        // maybe rename languageCode_Tanslation to languageDictionary or translations
        // check of termKey exists - should there be some update mechanism implemented (with boolean)?
        public static void AddTerm(string termKey, System.Collections.Generic.Dictionary<string, string> languageCode_Translation)
        {
            AddTerm(termKey, languageCode_Translation: languageCode_Translation, description: null);
        }

        /// <summary>
        /// Adds a <see cref="I2.Loc.TermData"/>
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="languageCode_Translation"></param>
        /// <param name="description"></param>
        public static void AddTerm(string termKey, System.Collections.Generic.Dictionary<string, string> languageCode_Translation, string description = null)
        {
            TermData termData = new TermData { Term = termKey, TermType = eTermType.Text, Description = description, Flags = new byte[GetLanguages().Count] };
            System.Collections.Generic.List<string> languages = Enumerable.Repeat("", GetLanguages().Count).ToList();
            foreach (System.Collections.Generic.KeyValuePair<string, string> entry in languageCode_Translation)
            {
                languages[GetLanguageIndexFromLanguageCode(entry.Key)] = entry.Value;
            }
            termData.Languages = languages.ToArray();
            AddTermData(termData);
        }

        /// <summary>
        /// Adds a <see cref="I2.Loc.TermData"/>
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="languageCode"></param>
        /// <param name="translation"></param>
        // maybe set languageCode = "en" as default
        public static void AddTerm(string termKey, string languageCode, string translation)
        {
            AddTerm(termKey, languageCode: languageCode, translation: translation, description: null);
        }

        /// <summary>
        /// Adds a <see cref="I2.Loc.TermData"/>
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="languageCode"></param>
        /// <param name="translation"></param>
        /// <param name="description"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public static void AddTerm(string termKey, string languageCode, string translation, string description = null)
        {
            System.Collections.Generic.List<string> languages = new System.Collections.Generic.List<string>(GetLanguages().Count);
            TermData termData = new TermData { Term = termKey, TermType = eTermType.Text, Flags = new byte[GetLanguages().Count] };

            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Updates the dictionary
        /// </summary>
        /// <param name="force"></param>
        public static void UpdateDictionary(bool force = false)
        {
            I2.Loc.LocalizationManager.Sources[0].UpdateDictionary(force);
        }

        /// <summary>
        /// Test method to add a 
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="english"></param>
        /// <param name="german"></param>
        public static void AddTermTest(string termKey, string english, string german)
        {
            System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
            dictionary.Add("en", english);
            dictionary.Add("de", german);
            AddTerm(termKey, dictionary);
        }

        /// <summary>
        /// Test method to add a predefined Term
        /// </summary>
        public static void AddTermTest1()
        {
            AddTermTest("TestKey123", "TestEnlish123", "TestGerman123");
        }

        /// <summary>
        /// Returns every translation for a given Term as a List
        /// </summary>
        /// <param name="termKey"></param>
        /// <returns></returns>
        public static System.Collections.Generic.List<string> GetTermTranslations(string termKey)
        {
            // converting UnhollowerBaseLib.Il2CppStringArray to Il2CppSystem.Collection.Generic.List<string>
            System.Collections.Generic.List<string> ret = new System.Collections.Generic.List<string>();
            foreach (string item in I2.Loc.LocalizationManager.Sources[0].GetTermData(termKey).Languages)
            {
                ret.Add(item);
            }
            return ret;
        }

        /// <summary>
        /// Returns every translation for a given Term as a typed Dictionary
        /// </summary>
        /// <param name="termKey"></param>
        /// <returns></returns>
        public static System.Collections.Generic.Dictionary<string, string> GetTermTranslationsDict(string termKey)
        {
            System.Collections.Generic.Dictionary<string, string> ret = new System.Collections.Generic.Dictionary<string, string>();
            int i = 0;
            foreach (string item in I2.Loc.LocalizationManager.Sources[0].GetTermData(termKey).Languages)
            {
                ret.Add(GetLanguageCode(i), item);
                i++;
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="termTranslations"></param>
        public static void SetTermTranslations(string termKey, System.Collections.Generic.Dictionary<string, string> termTranslations)
        {
            foreach (System.Collections.Generic.KeyValuePair<string, string> entry in termTranslations)
            {
                SetTermTranslation(termKey, languageCode: entry.Key, entry.Value, unused: true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="termTranslations"></param>
        public static void SetTermTranslations(string termKey, System.Collections.Generic.Dictionary<int, string> termTranslations)
        {
            foreach (System.Collections.Generic.KeyValuePair<int, string> entry in termTranslations)
            {
                SetTermTranslation(termKey, languageIndex: entry.Key, entry.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="termTranslations"></param>
        // should not be used at all - unsafe.
        [Obsolete("Avoid to use this method. Instead use SetTermTranslations with Dictionary.")]
        public static void SetTermTranslations(string termKey, System.Collections.Generic.List<string> termTranslations)
        {
            if (termTranslations.Count == GetLanguages().Count)
            {
                int i = 0;
                foreach (string item in termTranslations)
                {
                    SetTermTranslation(termKey, i, item);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="languageIndex"></param>
        /// <returns></returns>
        public static string GetTermTranslation(string termKey, int languageIndex)
        {
            return GetTermData(termKey).GetTranslation(languageIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="languageCode"></param>
        /// <param name="unused"></param>
        /// <returns></returns>
        public static string GetTermTranslation(string termKey, string languageCode, bool unused = true)
        {
            return GetTermData(termKey).GetTranslation(GetLanguageIndexFromLanguageCode(languageCode));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static string GetTermTranslation(string termKey, string language)
        {
            return GetTermData(termKey).GetTranslation(GetLanguageIndex(language));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="languageIndex"></param>
        /// <param name="translation"></param>
        public static void SetTermTranslation(string termKey, int languageIndex, string translation)
        {
            GetTermData(termKey).SetTranslation(languageIndex, translation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="languageCode"></param>
        /// <param name="translation"></param>
        /// <param name="unused"></param>
        public static void SetTermTranslation(string termKey, string languageCode, string translation, bool unused = true)
        {
            GetTermData(termKey).SetTranslation(GetLanguageIndexFromLanguageCode(languageCode), translation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="language"></param>
        /// <param name="translation"></param>
        public static void SetTermTranslation(string termKey, string language, string translation)
        {
            GetTermData(termKey).SetTranslation(GetLanguageIndex(language), translation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language"></param>
        /// <param name="skipDisabled"></param>
        /// <param name="allowDiscartingRegion"></param>
        /// <returns></returns>
        public static int GetLanguageIndex(string language, bool skipDisabled = false, bool allowDiscartingRegion = true)
        {
            return I2.Loc.LocalizationManager.Sources[0].GetLanguageIndex(language, allowDiscartingRegion, skipDisabled);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="languageCode"></param>
        /// <param name="exactMatch"></param>
        /// <param name="ignoreDisabled"></param>
        /// <returns></returns>
        public static int GetLanguageIndexFromLanguageCode(string languageCode, bool exactMatch = true, bool ignoreDisabled = false)
        {
            return I2.Loc.LocalizationManager.Sources[0].GetLanguageIndexFromCode(languageCode, exactMatch, ignoreDisabled);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="languageIndex"></param>
        /// <returns></returns>
        public static string GetLanguageCode(int languageIndex)
        {
            int i = 0;
            foreach (string item in GetLanguageCodes())
            {
                if (i == languageIndex)
                {
                    return item;
                }
                i++;
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public static string GetLanguageCode(string language)
        {
            foreach (LanguageData item in GetLanguages())
            {
                if (item.Name == language)
                {
                    return item.Code;
                }
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="languageIndex"></param>
        /// <returns></returns>
        public static string GetLanguage(int languageIndex)
        {
            int i = 0;
            foreach (LanguageData item in GetLanguages())
            {
                if (i == languageIndex)
                {
                    return item.Name;
                }
                i++;
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns></returns>
        public static string GetLanguage(string languageCode)
        {
            foreach (LanguageData item in GetLanguages())
            {
                if (item.Code == languageCode)
                {
                    return item.Name;
                }
            }
            return "";
        }

        /// <summary>
        /// Return all language codes as List
        /// </summary>
        /// <returns></returns>
        public static System.Collections.Generic.List<string> GetLanguageCodes()
        {
            System.Collections.Generic.List<string> langCode = new System.Collections.Generic.List<string>();
            var AllLanguages = GetLanguages();
            foreach (LanguageData _itemTerm in AllLanguages)
            {
                langCode.Add(_itemTerm.Code);
            }
            return langCode;
        }

        /// <summary>
        /// Return all language codes as Dictionary
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetLanguageCodesDict()
        {
            Dictionary<int, string> langCode = new Dictionary<int, string>();
            var AllLanguages = GetLanguages();
            foreach (LanguageData _itemTerm in AllLanguages)
            {
                langCode.Add(GetLanguageIndexFromLanguageCode(_itemTerm.Code), _itemTerm.Code);
            }
            return langCode;
        }

        /// <summary>
        /// Return active language
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentLanguage()
        {
            return I2.Loc.LocalizationManager.CurrentLanguage;
        }

        /// <summary>
        /// Return active language as code
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentLanguageCode()
        {
            return I2.Loc.LocalizationManager.CurrentLanguageCode;
        }

        /// <summary>
        /// Return active language as index
        /// </summary>
        /// <returns></returns>
        public static int GetCurrentLanguageIndex()
        {
            return GetLanguageIndex(GetCurrentLanguage());
        }

        /// <summary>
        /// Return all languages as List of type <see cref="LanguageData"/>
        /// </summary>
        /// <returns></returns>
        public static List<LanguageData> GetLanguages()
        {
            return I2.Loc.LocalizationManager.Sources[0].mLanguages;
        }

        /// <summary>
        /// Return all languages as List
        /// </summary>
        /// <returns></returns>
        public static List<string> GetLanguagesString()
        {
            return I2.Loc.LocalizationManager.Sources[0].GetLanguages(false);
        }

        /// <summary>
        /// Return boolean whether a given language is enabled
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public static bool IsEnabled(string language)
        {
            int i = 0;
            foreach (LanguageData item in GetLanguages())
            {
                if (i == GetLanguageIndex(language) || item.Code == GetLanguageCode(language) || item.Name == language)
                {
                    return item.IsEnabled();
                }
            }
            return false;
        }

        /// <summary>
        /// Return boolean whether a language given as code is enabled
        /// </summary>
        /// <param name="languageCode"></param>
        /// <param name="unused"></param>
        /// <returns></returns>
        public static bool IsEnabled(string languageCode, bool unused = true)
        {
            int i = 0;
            foreach (LanguageData item in GetLanguages())
            {
                if (i == GetLanguageIndexFromLanguageCode(languageCode) || item.Code == languageCode || item.Name == GetLanguage(languageCode))
                {
                    return item.IsEnabled();
                }
            }
            return false;
        }

        /// <summary>
        /// Return boolean whether a language given as index is enabled
        /// </summary>
        /// <param name="languageIndex"></param>
        /// <returns></returns>
        public static bool IsEnabled(int languageIndex)
        {
            int i = 0;
            foreach (LanguageData item in GetLanguages())
            {
                if (i == languageIndex || item.Code == GetLanguageCode(languageIndex) || item.Name == GetLanguage(languageIndex))
                {
                    return item.IsEnabled();
                }
            }
            return false;
        }

        /// <summary>
        /// Enable a language given by index
        /// </summary>
        /// <param name="languageIndex"></param>
        // TODO: Return boolean instead of using void?!
        public static void EnableLanguage(int languageIndex)
        {
            int i = 0;
            foreach (LanguageData item in GetLanguages())
            {
                if (i == languageIndex || item.Code == GetLanguageCode(languageIndex) || item.Name == GetLanguage(languageIndex))
                {
                    item.Flags = 0;
                }
            }
        }

        /// <summary>
        /// Enable a language given by code
        /// </summary>
        /// <param name="languageCode"></param>
        /// <param name="unused"></param>
        // TODO: Return boolean instead of using void?!
        public static void EnableLanguage(string languageCode, bool unused = true)
        {
            int i = 0;
            foreach (LanguageData item in GetLanguages())
            {
                if (i == GetLanguageIndexFromLanguageCode(languageCode) || item.Code == languageCode || item.Name == GetLanguage(languageCode))
                {
                    item.Flags = 0;
                }
            }
        }

        /// <summary>
        /// Enable a given language
        /// </summary>
        /// <param name="language"></param>
        // TODO: Return boolean instead of using void?!
        public static void EnableLanguage(string language)
        {
            int i = 0;
            foreach (LanguageData item in GetLanguages())
            {
                if (i == GetLanguageIndex(language) || item.Code == GetLanguageCode(language) || item.Name == language)
                {
                    item.Flags = 0;
                }
            }
        }

        /// <summary>
        /// Disable a language given by index
        /// </summary>
        /// <param name="languageIndex"></param>
        // TODO: Return boolean instead of using void?!
        public static void DisableLanguage(int languageIndex)
        {
            int i = 0;
            foreach (LanguageData item in GetLanguages())
            {
                if (i == languageIndex || item.Code == GetLanguageCode(languageIndex) || item.Name == GetLanguage(languageIndex))
                {
                    item.Flags = 1;
                }
            }
        }

        /// <summary>
        /// Disable a language given by code
        /// </summary>
        /// <param name="languageCode"></param>
        /// <param name="unused"></param>
        // TODO: Return boolean instead of using void?!
        public static void DisableLanguage(string languageCode, bool unused = true)
        {
            int i = 0;
            foreach (LanguageData item in GetLanguages())
            {
                if (i == GetLanguageIndexFromLanguageCode(languageCode) || item.Code == languageCode || item.Name == GetLanguage(languageCode))
                {
                    item.Flags = 1;
                }
            }
        }

        /// <summary>
        /// Disable a given language
        /// </summary>
        /// <param name="language"></param>
        // TODO: Return boolean instead of using void?!
        // TODO: Add boolean and check if language is English
        public static void DisableLanguage(string language)
        {
            int i = 0;
            foreach (LanguageData item in GetLanguages())
            {
                if (i == GetLanguageIndex(language) || item.Code == GetLanguageCode(language) || item.Name == language)
                {
                    item.Flags = 1;
                }
            }
        }

        /// <summary>
        /// Enable all languages
        /// </summary>
        // TODO: Return boolean instead of using void?!
        public static void EnableAllLanguages()
        {
            foreach (LanguageData item in GetLanguages())
            {
                item.Flags = 0;
            }
        }

        /// <summary>
        /// Disable all languages. English is excluded by default to avoid Game crashes.
        /// </summary>
        // TODO: Return boolean instead of using void?!
        public static void DisableAllLanguages(bool includeEnglish = false)
        {
            var enCode = GetLanguageCode("English");
            foreach (LanguageData item in GetLanguages())
            {
                if (includeEnglish)
                {
                    item.Flags = 1;
                }
                else
                {
                    if (item.Code == enCode)
                    {
                        item.Flags = 0;
                    }
                    else
                    {
                        item.Flags = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Return all disabled languages
        /// </summary>
        /// <returns></returns>
        public static List<LanguageData> GetDisabledLanguages()
        {
            List<LanguageData> ret = new List<LanguageData>();
            foreach (LanguageData item in I2.Loc.LocalizationManager.Sources[0].mLanguages)
            {
                if (!item.IsEnabled())
                {
                    ret.Add(item);
                }
            }
            return ret;
        }

        /// <summary>
        /// Return all disabled languages
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDisabledLanguagesString()
        {
            List<string> ret = new List<string>();
            List<LanguageData> DisabledLanguages = GetDisabledLanguages();
            foreach (LanguageData item in DisabledLanguages)
            {
                ret.Add(item.Name);
            }
            return ret;
        }

        /// <summary>
        /// Return all enabled languages
        /// </summary>
        /// <returns></returns>
        public static List<LanguageData> GetEnabledLanguages()
        {
            List<LanguageData> ret = new List<LanguageData>();
            foreach (LanguageData item in I2.Loc.LocalizationManager.Sources[0].mLanguages)
            {
                if (item.IsEnabled())
                {
                    ret.Add(item);
                }
            }
            return ret;
        }

        /// <summary>
        /// Return all enabled languages
        /// </summary>
        /// <returns></returns>
        public static List<string> GetEnabledLanguagesString()
        {
            return I2.Loc.LocalizationManager.Sources[0].GetLanguages(true);
        }

        public static TermData ObjectToTerm(object data, bool useDictForLanguages = true)
        {
            TermData term = new TermData();
            if (useDictForLanguages)
            {
                Type t = data.GetType();
                var _key = (string)data?.GetType().GetProperty("Key")?.GetValue(data);
                var _type = (eTermType)data?.GetType().GetProperty("Type")?.GetValue(data);
                var _desc = (string)data?.GetType().GetProperty("Desc")?.GetValue(data);
                var _languages = (System.Collections.Generic.Dictionary<string, string>)data?.GetType().GetProperty("Languages")?.GetValue(data);
                UnhollowerBaseLib.Il2CppStringArray _langs = new UnhollowerBaseLib.Il2CppStringArray(_languages.Values.ToArray());
                term.Term = _key;
                term.TermType = _type;
                term.Description = _desc;
                term.Languages = _langs;
                // AddTerm(termKey: _key, languageCode_Translation: _languages, description: _desc);
            }
            else
            {
                throw new NotImplementedException();
            }
            return term;
        }

        /// <summary>
        /// Return a Term as Object
        /// </summary>
        /// <param name="termData"></param>
        /// <param name="useDictForLanguages"></param>
        /// <returns></returns>
        public static object TermToObject(TermData termData, bool useDictForLanguages = true)
        {
            if (useDictForLanguages)
            {
                System.Collections.Generic.Dictionary<string, string> dictLang = new System.Collections.Generic.Dictionary<string, string>();
                int _i = 0;
                foreach (string _termLanguage in termData.Languages)
                {
                    dictLang.Add(GetLanguageCode(_i), _termLanguage);
                    _i++;
                }
                var _TermData = new
                {
                    Index = GetTermDataIndex(termData),
                    Key = termData.Term,
                    Type = termData.TermType,
                    Desc = termData.Description,
                    Languages = dictLang
                };
                return _TermData;
            }
            else
            {
                var _TermData = new
                {
                    Key = termData.Term,
                    Type = termData.TermType,
                    Desc = termData.Description,
                    Languages = termData.Languages
                };
                return _TermData;
            }
        }

        /// <summary>
        /// Return a Term as Object
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="useDictForLanguages"></param>
        /// <returns></returns>
        public static object TermToObject(string termKey, bool useDictForLanguages = true)
        {
            return TermToObject(GetTermData(termKey), useDictForLanguages: useDictForLanguages);
        }

        /// <summary>
        /// Return a Term as Object
        /// </summary>
        /// <param name="index"></param>
        /// <param name="useDictForLanguages"></param>
        /// <returns></returns>
        public static object TermToObject(int index, bool useDictForLanguages = true)
        {
            return TermToObject(GetTermDataAtIndex(index), useDictForLanguages: useDictForLanguages);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termKey"></param>
        /// <param name="prettyPrint"></param>
        /// <returns></returns>
        [Obsolete("Do not use!")]
        private static string _Unity_Term2Json(string termKey, bool prettyPrint = true)
        {
            return _Unity_Term2Json(GetTermData(termKey: termKey), prettyPrint: prettyPrint);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termData"></param>
        /// <param name="prettyPrint"></param>
        /// <returns></returns>
        [Obsolete("Do not use!")]
        private static string _Unity_Term2Json(TermData termData, bool prettyPrint = true)
        {
            return UnityEngine.JsonUtility.ToJson(termData, prettyPrint: prettyPrint);
        }

        public static void _TestExportJsonToFile()
        {
            ExportJsonToFile(TermsToJson(), "terms.json");
        }

        public static System.Collections.Generic.List<TermData> _TestJsonToTerms()
        {
            return JsonToTerms(TermsToJson(), useDictForLanguages: true);
        }

        public static System.Collections.Generic.List<JsonElement> _TestJsonToTerms2()
        {
            return JsonToObjects(TermsToJson(), useDictForLanguages: true);
        }

        /// <summary>
        /// Export a given JSON string to a named file
        /// </summary>
        /// <param name="json"></param>
        /// <param name="fileName"></param>
        /// <param name="filePath"></param>
        /// <param name="fileType"></param>
        public static void ExportJsonToFile(string json, string fileName, string filePath = null, string fileType = null)
        {
            Framework.Utilities.FileHelper.WriteToFile(content: json, fileName: fileName, filePath: filePath, fileType: fileType);
        }

        // BUG: is not working 
        public static System.Collections.Generic.List<TermData> JsonToTerms(string json, bool useDictForLanguages = true)
        {
            System.Collections.Generic.List<TermData> ret = new System.Collections.Generic.List<TermData>();
            System.Collections.Generic.List<string> langCode = GetLanguageCodes();
            System.Collections.Generic.List<JsonElement> _tmp = JsonSerializer.Deserialize<System.Collections.Generic.List<JsonElement>>(json);
            //ret.Add(ObjectToTerm(_tmp[0], useDictForLanguages: useDictForLanguages));
            foreach (var item in _tmp)
            {
                ret.Add(ObjectToTerm(item.GetRawText(), useDictForLanguages: useDictForLanguages));
            }
            return ret;
            // throw new NotImplementedException();
        }

        public static System.Collections.Generic.List<JsonElement> JsonToObjects(string json, bool useDictForLanguages = true)
        {
            System.Collections.Generic.List<JsonElement> ret = new System.Collections.Generic.List<JsonElement>();
            System.Collections.Generic.List<string> langCode = GetLanguageCodes();
            System.Collections.Generic.List<JsonElement> _tmp = JsonSerializer.Deserialize<System.Collections.Generic.List<JsonElement>>(json);
            foreach (var item in _tmp)
            {
                ret.Add(item);
            }
            return ret;
            // throw new NotImplementedException();
        }

        /// <summary>
        /// Return all Terms as a JSON string
        /// </summary>
        /// <param name="useDictForLanguages"></param>
        /// <param name="indendet"></param>
        /// <returns></returns>
        public static string TermsToJson(bool useDictForLanguages = true, bool indendet = true)
        {
            System.Collections.Generic.List<object> ret = new System.Collections.Generic.List<object>();

            // TODO: replace with GetLanguageCodes()
            System.Collections.Generic.List<string> langCode = new System.Collections.Generic.List<string>();
            if (useDictForLanguages)
            {
                var AllLanguages = GetLanguages();
                foreach (LanguageData _itemTerm in AllLanguages)
                {
                    langCode.Add(_itemTerm.Code);
                }
            }

            int i = 0;
            foreach (TermData item in I2.Loc.LocalizationManager.Sources[0].mTerms)
            {
                if (useDictForLanguages)
                {
                    System.Collections.Generic.Dictionary<string, string> dictLang = new System.Collections.Generic.Dictionary<string, string>();
                    int _i = 0;
                    foreach (string _termLanguage in item.Languages)
                    {
                        dictLang.Add(langCode[_i], _termLanguage);
                        _i++;
                    }
                    var _TermData = new
                    {
                        Index = i,
                        Key = item.Term,
                        Type = item.TermType,
                        Desc = item.Description,
                        Languages = dictLang
                    };
                    ret.Add(_TermData);
                    i++;
                }
                else
                {
                    var _TermData = new
                    {
                        Index = i,
                        Key = item.Term,
                        Type = item.TermType,
                        Desc = item.Description,
                        Languages = item.Languages
                    };
                    ret.Add(_TermData);
                    i++;
                }

            }
            string json = JsonSerializer.Serialize(ret, options: new JsonSerializerOptions { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, WriteIndented = indendet });
            return json;
        }

        /// <summary>
        /// Change the language
        /// </summary>
        /// <param name="languageCode"></param>
        /// <param name="forceEnable"></param>
        /// <param name="unused"></param>
        public static void ChangeAndApplyLanguage(string languageCode, bool forceEnable = false, bool unused = true)
        {
            ChangeAndApplyLanguage(GetLanguage(languageCode), forceEnable: forceEnable);
        }

        /// <summary>
        /// Change the language
        /// </summary>
        /// <param name="languageIndex"></param>
        /// <param name="forceEnable"></param>
        public static void ChangeAndApplyLanguage(int languageIndex, bool forceEnable = false)
        {
            ChangeAndApplyLanguage(GetLanguage(languageIndex), forceEnable: forceEnable);
        }

        /// <summary>
        /// Change the language
        /// </summary>
        /// <param name="language"></param>
        /// <param name="forceEnable"></param>
        public static void ChangeAndApplyLanguage(string language, bool forceEnable = false)
        {
            if (forceEnable)
            {
                EnableLanguage(language);
            }
            if (IsEnabled(language))
            {
                // lazy and cheap (set_CurrentLanguage is handling everything for us - also invokes LocalizeAll)
                I2.Loc.LocalizationManager.CurrentLanguage = language;

                /*
                // full implementation
                I2.Loc.LocalizationManager.InitializeIfNeeded();
                var SupportedLanguage = I2.Loc.LocalizationManager.GetSupportedLanguage(lang, false);
                // if SupportedLanguage
                var LanguageCode = I2.Loc.LocalizationManager.GetLanguageCode(SupportedLanguage);
                I2.Loc.LocalizationManager.SetLanguageAndCode(SupportedLanguage, LanguageCode, true, false);
                */

                // then update all objects of type PugText by invoking render on each of them
                var PugTextObjects = FindPugTextObjects();
                foreach (PugText _PugText in PugTextObjects)
                {
                    if (_PugText.localize)
                    {
                        _PugText.Render(false);
                    }
                }
            }
        }

        /// <summary>
        /// Find all Objects of type PugText
        /// </summary>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        // move this method to some helper class
        public static PugText[] FindPugTextObjects(bool includeInactive = false)
        {
            return UnityEngine.Object.FindObjectsOfType<PugText>(includeInactive);
        }
    }
}