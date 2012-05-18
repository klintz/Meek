set connectionstring="Data Source=.\ALPHA;Initial Catalog=G.Demo;Integrated Security=True"
set namespace="Meek"
set language="CSharp"
set outputobjectlayer="output\Entities.cs"
set outputssdl="output\Meek.ssdl"
set outputcsdl="output\Meek.csdl"
set outputmsl="output\Meek.msl"
set outputview="output\View.cs"
set entitycontainer="Meek"

EdmGen /mode:fullgeneration /connectionstring:%connectionstring% /namespace:%namespace% /language:%language% /outobjectlayer:%outputobjectlayer% /outssdl:%outputssdl% /outcsdl:%outputcsdl% /outmsl:%outputmsl% /outviews:%outputview% /entitycontainer:%entitycontainer% /nologo
