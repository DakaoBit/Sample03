using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sample03.Model;

namespace Sample03
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
   
        }


        /// <summary>
        /// 新增人員
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addPerson(object sender, EventArgs e)
        {
            //取得資料
            var Person = new PersonViewModel()
            {
                account = account.Value,
                birth = Convert.ToDateTime(birth.Value),
                position = position.SelectedValue,
                skill = skill.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList() //取出勾選的項目值
            };

            //使用 Session 傳值
            Session["Person"] = Person;
            Response.Redirect("GetData.aspx");
        }

        /// <summary>
        /// 變更工作技能顯示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void selectSkill(object sender, EventArgs e)
        {
            //設定 Skill 列表
            switch (position.SelectedValue)
            {
                case "主管":
                    if (skill.Items.FindByValue("管理手法") == null && skill.Items.FindByValue("管理技巧") == null)
                    {
                        skill.Items.Add("管理手法");
                        skill.Items.Add("管理技巧");
                    }

                    skill.Items.Remove("ASP.NET");
                    skill.Items.Remove("SQL");
                    skill.Items.Remove("簡報技巧");
                    skill.Items.Remove("談判銷售");
                    break;

                case "工程師":
                    skill.Items.Add("ASP.NET");
                    skill.Items.Add("SQL");
                    skill.Items.Remove("管理手法");
                    skill.Items.Remove("管理技巧");
                    skill.Items.Remove("簡報技巧");
                    skill.Items.Remove("談判銷售");
                    break;

                case "業務":
                    skill.Items.Add("簡報技巧");
                    skill.Items.Add("談判銷售");
                    skill.Items.Remove("管理手法");
                    skill.Items.Remove("管理技巧");
                    skill.Items.Remove("ASP.NET");
                    skill.Items.Remove("SQL");
                    break;
            }



        }

       
    }
}