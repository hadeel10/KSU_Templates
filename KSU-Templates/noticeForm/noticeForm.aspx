  <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="noticeForm.aspx.cs" Inherits="KSU_Templates.noticeForm.WebForm1" %>



  

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content> 

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  
        <div style="margin-left:80px">  
            <br /> <br /><br /><br /><br /><br />
            <asp:Label runat="server">Effective Date Notice Form</asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br /><br />
            <table class="auto-style1">  
                <tr>  
                    <td>Institution</td>  
                    <td>  
                        <asp:DropDownList ID="ddInstitution" runat="server" DataSourceID="SqlDataSource1" DataTextField="institution" DataValueField="institutionId">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KSU_TemplatesConnectionString %>" SelectCommand="SELECT [institutionId], [institution] FROM [institution]"></asp:SqlDataSource>
                    </td>  
  
               </tr>  
                <tr>  
                    <td>ID </td>  
                     <td> <asp:TextBox ID="tId" runat="server"></asp:TextBox></td>  
                </tr>  

                 <tr>  
                    <td>Training Starting Date </td>  
                     <td> 
                         <asp:Calendar ID="startinDate" runat="server" Height="100px" Width="100px"></asp:Calendar>  

                     </td>  
                </tr>  
                
                <tr>  
                    <td>  
                        <asp:Button ID="generate" runat="server" Text="Generate" OnClick="generate_Click" />  
                    </td>  
                </tr>  
            </table> 
            
            <div>
        <asp:GridView ID="gvInternData" runat="server"></asp:GridView>

    </div>

        </div>  
   
</asp:Content>
    <asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
 