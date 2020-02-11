<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetData.aspx.cs" Inherits="Sample03.GetData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <label class="h2">列出 SkillList 節點下的 skill</label>
        <br />
        <!-- 顯示技能清單 -->
        <asp:Label ID="Label1" runat="server" Text="Label" CssClass="h4"></asp:Label>
    </div>

</asp:Content>
