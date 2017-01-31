using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReactiveUI.scripts.Localization
{
    public class LocalizationManager
    {
        /// <summary>
        /// Stores a 2-character language code. (EN = English, MY=Bahasa Malaysia)
        /// </summary>
        protected string lang_tag;
        public string LangTag
        {
            get { return lang_tag; }
            set { lang_tag = value; }
        }

        /// <summary>
        /// Holds all the loaded strings from the language file
        /// </summary>
        Dictionary<string, string> m_strings = new Dictionary<string, string>();

        /// <summary>
        /// Loads the language file from the system
        /// </summary>
        /// <param name="tag">The 2-character language code</param>
        public void LoadLocalization(string tag = null)
        {
            try
            {
                XDocument xmlFile;
                if (String.IsNullOrEmpty(tag))
                {
                    xmlFile = XDocument.Load(Constants.langResource + lang_tag + ".xml");
                }
                else
                {
                    xmlFile = XDocument.Load(Constants.langResource + tag + ".xml");
                }

                XElement root = xmlFile.Element("Localization");

                var texts = root.Descendants("Text");
                if (texts != null)
                {
                    texts.ForEach(text =>
                    {
                        var items = text.Elements("Item");
                        if (items != null)
                        {
                            //XElement locStringXml = items.FirstOrDefault(item => item.Attribute("language").Value.ToString() == lang_tag);
                            //if (locStringXml != null)
                            //{
                            m_strings.Add(text.Attribute("name").Value.ToString(), text.Attribute("value").Value.ToString());
                            //}
                        }
                    });
                }
            }
            catch(Exception ex)
            {
                ReactiveUI.GUI.MessageBox.ShowMessage(ex.ToString(), "Exception in LocalizationManager");
            }
        }

        /// <summary>
        /// Gets the text from the list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public String GetText(string name)
        {
            if (m_strings.ContainsKey(name))
            {
                return m_strings[name];
            }
            return name;
        }
    }

    public static class LangExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> values, Action<T> action)
        {
            foreach (var v in values)
            {
                action(v);
            }
        }
    }
}
