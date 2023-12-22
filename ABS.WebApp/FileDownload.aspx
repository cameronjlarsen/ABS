<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="FileDownload.aspx.cs" Inherits="ABS.WebApp.FileDownload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="DownloadButton" CssClass="btn btn-default" runat="server" Text="Download" OnClick="DownloadButton_Click" />
            <asp.Label ID="ErrorMessageLabel" CssClass="text-danger" runat="server"  visible="false"/>
        </div>
    </form>
</body>
</html>
