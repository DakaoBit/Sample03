using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample03.Model
{

    /// <summary>
    /// User XML 文件格式 
    /// </summary>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class User
    {
        private string userIDField;

        private System.DateTime birthDayField;

        private string jobTitleField;

        private string[] skillListField;

        /// <remarks/> User 帳號
        public string UserID
        {
            get
            {
                return this.userIDField;
            }
            set
            {
                this.userIDField = value;
            }
        }

        /// <remarks/> User 生日
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime BirthDay
        {
            get
            {
                return this.birthDayField;
            }
            set
            {
                this.birthDayField = value;
            }
        }

        /// <remarks/> User 職稱
        public string JobTitle
        {
            get
            {
                return this.jobTitleField;
            }
            set
            {
                this.jobTitleField = value;
            }
        }

        /// <remarks/> User 業務
        [System.Xml.Serialization.XmlArrayItemAttribute("Skill", IsNullable = false)]
        public string[] SkillList
        {
            get
            {
                return this.skillListField;
            }
            set
            {
                this.skillListField = value;
            }
        }


    }
}