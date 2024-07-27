<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                <asp:GridView ID="gvLineChart" runat="server" OnSelectedIndexChanged="gvLineChart_SelectedIndexChanged">
                </asp:GridView>
            </td>
            <td>
                <div id="MyLineChart"></div>
            </td>
        </tr>
    </table>

    <table>
        <tr>
            <td>New tbale</td>
        </tr>
    </table>

 
    <script src="https://code.highcharts.com/highcharts.js"></script>
    <script>
        $(document).ready(function () {
            var lineData = <%=lineData%>;

            $('#MyLineChart').highcharts({
                chart: {
                    type: 'bar'  /*spline,bar,pie*/
                },
                title: {
                    text: 'Monthly High Temp Counts'
                },
                xAxis: {
                    title: {
                        text: 'Month'
                    }
                },
                yAxis: {
                    title: {
                        text: 'Count'
                    }
                },
                series: [{
                    type: 'bar',
                    name: 'Monthly High Temp',
                    data: lineData
                }]
            });
        });

    </script>
</asp:Content>


