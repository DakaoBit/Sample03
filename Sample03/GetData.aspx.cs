using Sample03.Model;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Sample03
{
    public partial class GetData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 用 Session 存取 Person
            PersonViewModel person = (PersonViewModel)Session["Person"];
            Session.Remove("Person");

            // 將 Person 轉為 User Object
            var user = new User()
            {
                UserID = person.account,
                BirthDay = person.birth.Value,
                JobTitle = person.position,
                SkillList = person.skill.ToArray()
            };

            var xml = "";
            // 產生 User 型別的序列化文件
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
            using (var sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    //將 user object 寫入 writer
                    xmlSerializer.Serialize(writer, user);
                    xml = sw.ToString(); // 產 User.XML String
                }
            }

            //設定檔案路徑及檔名
            var filePath = Path.Combine(Server.MapPath("~/Temp/"),"User.xml");

            //儲存 User.XML
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xml);
            xdoc.Save(filePath);

            #region 用 SelectSingleNode 找尋 SkillList 下的 Skill

            //找尋節點 skill
            XmlNode skillList;
            XmlNode root = xdoc.DocumentElement;
            skillList = root.SelectSingleNode("SkillList"); //找到 工作技能

            string print = "";

            //列出 工作技能節點下的 技能節點
            for (int i = 0; i < skillList.ChildNodes.Count; i++)
            {
                print += skillList.ChildNodes[i].InnerText;

                if (skillList.ChildNodes[i] != skillList.LastChild)
                {
                    print += ", ";
                }
            }

            #endregion


            //存取技能清單
            Label1.Text = print;
        }

       
    }
}