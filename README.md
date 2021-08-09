# PCF-Explorer
A tool to explore PCF dependencies.<br/>

- Type (Field/Dataset)
- Properties (Required, type, name)
- Resources (js/resx)
- Connected Forms/dashboard/Entities
- Solutions
- Search PCF controls
- Quick count of Control Types (Pire Chart)
- Quick glamnce of Control Types

More detial please see below.<br/>
# [Go to Application (examples)](#application-explanation)<br/>
# [Go to Conections](#how-to-connect-in-xrmtoolbox-connection-types)<br/>

## Application Explanation
 ![Application](https://raw.githubusercontent.com/yesadahmed/PCF-Explorer/main/main.png)
 
 ## How to Connect in xrmtoolbox (connection Types)
Once you have the xrmtoolbox you need to install this plugin form Tool Library as shown below.<br/>
![xrmtoolbox connections](https://raw.githubusercontent.com/yesadahmed/PowerAutomateManagerDocs/main/Plugin.PNG)

Once the installion is done, you will see this plugin as follows:
![xrmtoolbox connections](https://raw.githubusercontent.com/yesadahmed/PCF-Explorer/main/control.PNG)

Since this plugin connects to CE webapi so by default it requires **OAuth or Certifcate** type connections in xrmtoolbox.
<br/>For example regarding available OAuth connections in xrmtools are mentioned below:

![xrmtoolbox connections](https://github.com/yesadahmed/xrmtoolboxAddins/raw/main/JsonToCSharp/images/Conn1.png)

Some examples are as follows.

![xrmtoolbox connections](https://github.com/yesadahmed/xrmtoolboxAddins/blob/main/JsonToCSharp/images/sdkcontrol.png)

![xrmtoolbox connections](https://github.com/yesadahmed/xrmtoolboxAddins/blob/main/JsonToCSharp/images/conneciont.PNG)
 AuthType=OAuth;Username=jsmith@contoso.onmicrosoft.com; Password=passcode;
Url=https://contoso:8080/Test;AppId=<GUID>;RedirectUri=app://<GUID>; LoginPrompt=Never
