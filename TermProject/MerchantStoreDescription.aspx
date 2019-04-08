<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantStoreDescription.aspx.cs" Inherits="TermProject.MerchantStoreDescription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

 p.MsoNormal
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:8.0pt;
	margin-left:0in;
	line-height:107%;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;
	}
p.MsoListParagraphCxSpFirst
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	margin-bottom:.0001pt;
	line-height:107%;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;
	}
p.MsoListParagraphCxSpMiddle
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	margin-bottom:.0001pt;
	line-height:107%;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;
	}
p.MsoListParagraphCxSpLast
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:8.0pt;
	margin-left:.5in;
	line-height:107%;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;
	}
a:link
	{color:#0563C1;
	text-decoration:underline;
	text-underline:single;
        }
pre
	{margin-bottom:.0001pt;
	font-size:10.0pt;
	font-family:"Courier New";
	        margin-left: 0in;
            margin-right: 0in;
            margin-top: 0in;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Classes</h1>
            <p class="MsoNormal">
                None of these classes have any method. All of them are used to store and return data back as a list, except for Order class, which only stores quantity, product_id, and customer_id, but return for properties, also as a list. <o:p></o:p>
            </p>
            <p class="MsoNormal">
                Department class<o:p></o:p></p>
            <p class="MsoListParagraphCxSpFirst" style="margin-left:.75in;mso-add-space:auto;
text-indent:-.25in;mso-list:l0 level1 lfo1">
                <![if !supportLists]><span style="font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:
Symbol"><span style="mso-list:Ignore">·<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]>Fields<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                department_id<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                name <o:p></o:p>
            </p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:-.25in;mso-list:l0 level1 lfo1">
                <![if !supportLists]><span style="font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:
Symbol"><span style="mso-list:Ignore">·<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]>Properties <o:p></o:p>
            </p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Department_ID<o:p></o:p></p>
            <p class="MsoListParagraphCxSpLast" style="margin-left:.75in;mso-add-space:auto;
text-indent:.25in">
                Name<o:p></o:p></p>
            <p class="MsoNormal">
                Product class<o:p></o:p></p>
            <p class="MsoListParagraphCxSpFirst" style="margin-left:.75in;mso-add-space:auto;
text-indent:-.25in;mso-list:l0 level1 lfo1">
                <![if !supportLists]><span style="font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:
Symbol"><span style="mso-list:Ignore">·<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]>Fields<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                product_id<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                desc<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                price<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                image<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:-.25in;mso-list:l0 level1 lfo1">
                <![if !supportLists]><span style="font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:
Symbol"><span style="mso-list:Ignore">·<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]>Properties <o:p></o:p>
            </p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Product_id<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Desc<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Price<o:p></o:p></p>
            <p class="MsoListParagraphCxSpLast" style="margin-left:.75in;mso-add-space:auto;
text-indent:.25in">
                Image<o:p></o:p></p>
            <p class="MsoNormal">
                Merchant class<o:p></o:p></p>
            <p class="MsoListParagraphCxSpFirst" style="margin-left:.75in;mso-add-space:auto;
text-indent:-.25in;mso-list:l0 level1 lfo1">
                <![if !supportLists]><span style="font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:
Symbol"><span style="mso-list:Ignore">·<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]>Fields<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                apikey<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                seller_site<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                desc<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                email<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                phone <o:p></o:p>
            </p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:-.25in;mso-list:l0 level1 lfo1">
                <![if !supportLists]><span style="font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:
Symbol"><span style="mso-list:Ignore">·<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]>Properties <o:p></o:p>
            </p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Apikey<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Seller_site<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Desc<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Email<o:p></o:p></p>
            <p class="MsoListParagraphCxSpLast" style="margin-left:.75in;mso-add-space:auto;
text-indent:.25in">
                Phone <o:p></o:p>
            </p>
            <p class="MsoNormal">
                Order class<o:p></o:p></p>
            <p class="MsoListParagraphCxSpFirst" style="margin-left:.75in;mso-add-space:auto;
text-indent:-.25in;mso-list:l0 level1 lfo1">
                <![if !supportLists]><span style="font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:
Symbol"><span style="mso-list:Ignore">·<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]>Fields<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                quantity<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                product_id<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                apikey<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                seller_site<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                customer_id<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                name<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                address<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                email<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                phone <o:p></o:p>
            </p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:-.25in;mso-list:l0 level1 lfo1">
                <![if !supportLists]><span style="font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:
Symbol"><span style="mso-list:Ignore">·<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]>Properties <o:p></o:p>
            </p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Quantity<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Product_ID<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Apikey<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Seller_site<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Customer_ID<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Name<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Address<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Email<o:p></o:p></p>
            <p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in;mso-add-space:
auto;text-indent:.25in">
                Phone <o:p></o:p>
            </p>
            <p class="MsoListParagraphCxSpLast" style="margin-left:.75in;mso-add-space:auto;
text-indent:.25in">
                <o:p>&nbsp;</o:p></p>
            <h1>WEB API DOCUMENTATION</h1>
            <p class="MsoNormal">
            <h2>Get All Department API Method</h2>
            <p class="MsoNormal">
                This API method will get all of the departments in the database<o:p></o:p></p>
            <p class="MsoNormal">
                URL:</p>
            <p class="MsoNormal">
                <span style="font-size:9.5pt;line-height:107%;font-family:
Consolas;mso-bidi-font-family:Consolas;color:#A31515"><a href="http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/TermProjectWS/api/service/Merchants/">http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/TermProjectWS/api/service/Merchants/</a><o:p></o:p></span></p>
            <p class="MsoNormal">
                <span style="font-size:9.5pt;line-height:107%;font-family:
Consolas;mso-bidi-font-family:Consolas;color:#A31515">JSON<o:p></o:p></span></p>
            <pre><span style="color:#C00000">[{&quot;department_ID&quot;:1,&quot;name&quot;:&quot;Amazon Devices&quot;},<o:p></o:p></span></pre>
            <pre><span style="color:#C00000">{&quot;department_ID&quot;:2,&quot;name&quot;:&quot;Books&quot;},<o:p></o:p></span></pre>
            <pre><span style="color:#C00000">{&quot;department_ID&quot;:3,&quot;name&quot;:&quot;Computers&quot;},<o:p></o:p></span></pre>
            <pre><span style="color:#C00000">{&quot;department_ID&quot;:4,&quot;name&quot;:&quot;Electronics&quot;},<o:p></o:p></span></pre>
            <pre><span style="color:#C00000">{&quot;department_ID&quot;:5,&quot;name&quot;:&quot;Home &amp; Kitchen&quot;}]<o:p></o:p></span></pre>
            <pre><span style="font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-latin;color:#C00000"><o:p>&nbsp;</o:p></span></pre>
            <pre><span style="font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-latin;color:black;
mso-themecolor:text1"><o:p>&nbsp;</o:p></span></pre>
            <pre><span style="font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-latin;color:black;
mso-themecolor:text1"><o:p>&nbsp;</o:p></span></pre>
            <h2>Get Product by Department Number API Method</h2>
            <p class="MsoNormal">
                This API method will get all of the products that belong to a specific department. Please replace (DepartmentID) with your desired department ID<o:p></o:p></p>
            <p class="MsoNormal">
                URL:</p>
            <p class="MsoNormal">
                <span style="font-size:9.5pt;line-height:107%;font-family:
Consolas;mso-bidi-font-family:Consolas;color:#A31515"><a href="http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/TermProjectWS/api/service/Merchants/GetProductCatalog/(DepartmentID)/">http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/TermProjectWS/api/service/Merchants/GetProductCatalog/(DepartmentID)/</a><o:p></o:p></span></p>
            <p class="MsoNormal">
                <span style="color:#C00000">JSON<o:p></o:p></span></p>
            <pre><span style="color:#C00000">[{&quot;product_ID&quot;:34,&quot;desc&quot;:&quot;Apple MacBook Air (13&#39;&#39;)&quot;,&quot;price&quot;:1099.99,&quot;image&quot;:&quot;&quot;},</span></pre>
            <pre><span style="color:#C00000">{&quot;product_ID&quot;:35,&quot;desc&quot;:&quot;Apple MacBook Pro (13&#39;&#39;)&quot;,&quot;price&quot;:1210.71,&quot;image&quot;:&quot;&quot;},</span></pre>
            <pre><span style="color:#C00000">{&quot;product_ID&quot;:36,&quot;desc&quot;:&quot;Apple IMac Pro&quot;,&quot;price&quot;:4649.0,&quot;image&quot;:&quot;&quot;},</span></pre>
            <pre><span style="color:#C00000">{&quot;product_ID&quot;:37,&quot;desc&quot;:&quot;Microsoft Surface Pro 4 (12.3&#39;&#39;)&quot;,&quot;price&quot;:645.0,&quot;image&quot;:&quot;&quot;},</span></pre>
            <pre><span style="color:#C00000">{&quot;product_ID&quot;:38,&quot;desc&quot;:&quot;Microsoft Surface Go&quot;,&quot;price&quot;:374.99,&quot;image&quot;:&quot;&quot;},</span></pre>
            <pre><span style="color:#C00000">{&quot;product_ID&quot;:39,&quot;desc&quot;:&quot;Microsoft Surface Book 2&quot;,&quot;price&quot;:1499.0,&quot;image&quot;:&quot;&quot;}]<o:p></o:p></span></pre>
            <p class="MsoNormal">
                <o:p>&nbsp;</o:p></p>
            <h2>Register Merchant API Method</h2>
            <p class="MsoNormal">
                This API method will add a merchant to the database by adding the merchant seller site, description, email and phone number<o:p></o:p></p>
            <p class="MsoNormal">
                URL:</p>
            <p class="MsoNormal">
                <span style="font-size:9.5pt;line-height:107%;font-family:
Consolas;mso-bidi-font-family:Consolas;color:#A31515"><a href="http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/TermProjectWS/api/service/Merchants/Register/Merchant/">http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/TermProjectWS/api/service/Merchants/Register/Merchant/</a><o:p></o:p></span></p>
            <p class="MsoNormal">
                <span style="mso-spacerun:yes">&nbsp;</span>JSON<o:p></o:p></p>
            <p class="MsoNormal">
                <span style="mso-tab-count:1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style="font-family:&quot;Courier New&quot;;color:#C00000">{<o:p></o:p></span></p>
            <p class="MsoNormal">
                <span style="font-family:&quot;Courier New&quot;;color:#C00000"><span style="mso-tab-count:1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>&quot;Seller_site&quot;: &quot;spring&quot;,<o:p></o:p></span></p>
            <p class="MsoNormal">
                <span style="font-family:&quot;Courier New&quot;;color:#C00000"><span style="mso-tab-count:1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>&quot;Desc&quot;: &quot;spring water&quot;,<o:p></o:p></span></p>
            <p class="MsoNormal">
                <span style="font-family:&quot;Courier New&quot;;color:#C00000"><span style="mso-tab-count:1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>&quot;Email&quot;: &quot;springwater@gmail.com&quot;,<o:p></o:p></span></p>
            <p class="MsoNormal">
                <span style="font-family:&quot;Courier New&quot;;color:#C00000"><span style="mso-tab-count:1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>&quot;Phone&quot;: &quot;16950001079&quot;<o:p></o:p></span></p>
            <p class="MsoNormal" style="text-indent:.5in">
                <span style="font-family:&quot;Courier New&quot;;
color:#C00000">}<o:p></o:p></span></p>
            <p class="MsoNormal">
                <span style="font-family:&quot;Courier New&quot;;color:#C00000"><o:p>&nbsp;</o:p></span></p>
            <h2>Record API method</h2>
            <p class="MsoNormal">
                This API will record the order that was made by a customer into the database. This method accepts an Order object which includes the order quantity, product id and customer id<o:p></o:p></p>
            <p class="MsoNormal">
                URL:</p>
            <p class="MsoNormal">
                <span style="font-size:9.5pt;line-height:107%;font-family:
Consolas;mso-bidi-font-family:Consolas;color:#A31515"><a href="http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/TermProjectWS/api/service/Merchants/Record/Purchase/">http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/TermProjectWS/api/service/Merchants/Record/Purchase/</a><o:p></o:p></span></p>
            <p class="MsoNormal">
                JSON<o:p></o:p></p>
            <p class="MsoNormal">
                <span style="mso-tab-count:1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style="font-family:&quot;Courier New&quot;;color:#C00000">{<o:p></o:p></span></p>
            <p class="MsoNormal">
                <span style="font-family:&quot;Courier New&quot;;color:#C00000"><span style="mso-tab-count:1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>&quot;Quantity&quot;: &quot;4&quot;,<o:p></o:p></span></p>
            <p class="MsoNormal">
                <span style="font-family:&quot;Courier New&quot;;color:#C00000"><span style="mso-tab-count:1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>&quot;Product_ID&quot;: &quot;2&quot;,<o:p></o:p></span></p>
            <p class="MsoNormal">
                <span style="font-family:&quot;Courier New&quot;;color:#C00000"><span style="mso-tab-count:1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>&quot;Customer_ID&quot;: &quot;1&quot;,<o:p></o:p></span></p>
            <p class="MsoNormal" style="text-indent:.5in">
                <span style="font-family:&quot;Courier New&quot;;
color:#C00000">}<o:p></o:p></span></p>
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
