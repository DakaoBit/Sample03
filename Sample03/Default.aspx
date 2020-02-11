<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sample03._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- 新增人員 -->
    <div class="jumbotron">
        
        <!-- 帳號 -->
        <div class="form-group">
            <label class="h3">帳號</label>
            <input id="account" type="text" runat="server" class="form-control" />
            <!-- RequiredFieldValidator -->
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請輸入帳號!" ControlToValidate="account" CssClass="text-danger" ></asp:RequiredFieldValidator>
            <br />
             <!-- RegularExpressionValidator -->
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="[a-zA-Z0-9]{4}" ErrorMessage="帳號請四個英文字母或數字!" ControlToValidate="account" CssClass="text-danger"></asp:RegularExpressionValidator>
        </div>

        <!-- 生日 -->
        <div class="form-group">
            <label class="h3">生日</label>
            <input id="birth" runat="server" type="date" value="" class="form-control" />
            <!-- RequiredFieldValidator -->
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="請輸入生日!" ControlToValidate="birth" CssClass="text-danger"></asp:RequiredFieldValidator>
            <br />
             <!-- RegularExpressionValidator -->
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="請輸入正確的日期格式!正確格式為：2000/01/01" ValidationExpression="^[1-9]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$" ControlToValidate="birth" CssClass="text-danger"></asp:RegularExpressionValidator>
        </div>

        <!-- 職稱 -->
        <div class="form-group">
            <label class="h3">職稱</label>
            <div class="h4">
                <label>
                    <asp:RadioButtonList ID="position" runat="server" OnSelectedIndexChanged="selectSkill" AutoPostBack="true" >
                        <asp:ListItem Selected="True" Value="主管">主管</asp:ListItem>
                        <asp:ListItem Value="工程師">工程師</asp:ListItem>
                        <asp:ListItem Value="業務">業務</asp:ListItem>
                    </asp:RadioButtonList>
                </label>
            </div>
              <!-- RequiredFieldValidator -->
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="請選擇職稱!" ControlToValidate="position" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>

        <!-- 工作技能 -->
        <div class="form-group">
            <label class="h3">工作技能</label>
            <div class="h4">
                <asp:CheckBoxList ID="skill" runat="server">
                        <asp:ListItem Value="管理手法">管理手法</asp:ListItem>
                        <asp:ListItem Value="管理技巧">管理技巧</asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <!-- CustomValidator -->
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="請至少勾選一項!" ClientValidationFunction="ValidateCheckBoxList" CssClass="text-danger"></asp:CustomValidator>
        </div>
        <!-- 按鈕 -->
        <asp:Button ID="btnSend" runat="server" type="submit" Text="送出" CssClass="btn btn-primary" OnClick="addPerson" />        
    </div>


    <script type="text/javascript">
        /**
         * CheckBoxList: 檢查是否有勾選 checkbox
         * @param sender
         * @param args
         */
        function ValidateCheckBoxList(sender, args) {
            //取得 Skill ID
            var checkBoxList = document.getElementById("<%=skill.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                }
            }
            args.IsValid = isValid;
        }

      
    </script>

</asp:Content>
