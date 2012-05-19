## Meek - Framework © Michael Dela Cuesta 2012 (michael.dcuesta@gmail.com)


Contents
--------------------------------------------------------------------------------------------------
1. Meek
  1.1 Meek
  1.2 Author
  
2. Source Structure
  2.1 Folder Structure
  2.2 Solution Files
  
3. Building the Source
  3.1 Building Manually
  3.2 Building with MS-Build using NAnt Build Scripts
  
4. License
  4.1 Microsoft Public License (Ms-PL)


1. Meek
--------------------------------------------------------------------------------------------------
1.1 Meek - is a set of reusable design used for developing database driven enterprise applications.

1.2 Author: Michael Dela Cuesta (michael.dcuesta@gmail.com)



2. Source Structure
--------------------------------------------------------------------------------------------------

2.1 Folder Structure
1Build ------------------------------------------------ Contains tools and scripts used for building
..Build ----------------------------------------------- Build Output Folder
..Scripts --------------------------------------------- Contains the build scripts
1Solution --------------------------------------------- Contains Project Solutions
Assemblies -------------------------------------------- Referenced Assemblies Folder
bin --------------------------------------------------- Meek Projects Output Folder
CodeGenerator ----------------------------------------- Code Generator Tools
..output ---------------------------------------------- Code Generator Output Folder
Documents --------------------------------------------- Contains Project Documents
Keys -------------------------------------------------- Contains Signing Key
Meek -------------------------------------------------- Meek Project Folder
Meek.Business ----------------------------------------- Meek.Business Project Folder
Meek.Data --------------------------------------------- Meek.Data Project Folder
Meek.Forms -------------------------------------------- Meek.Forms Project Folder
Meek.Presentation ------------------------------------- Meek.Presentation Project Folder
Meek.Web ---------------------------------------------- Meek.Web Project Folder
Meek.Mvc ---------------------------------------------- Meek.Mvc Project Folder
Plugins ----------------------------------------------- Plugins Folder
..Data ------------------------------------------------ Meek.Data Plugins Folder
....Meek.Data.EntityFramework ------------------------- Meek.Data.EntityFramework Plugin Folder
....Meek.Data.LinqToSql ------------------------------- Meek.Data.LinqToSql Plugin Folder
....Unit.Test ----------------------------------------- Meek.Data Plugins Unit Tests Folder
......Test.Meek.Data.EntityFramework ------------------ Meek.Data.EntityFramework Unit Test
......Test.Meek.Data.LinqToSql ------------------------ Meek.Data.LinqToSql Unit Test
Tools ------------------------------------------------- Tools Folder
..NAnt ------------------------------------------------ NAnt
..NUnit ----------------------------------------------- NUnit
Unit.Test --------------------------------------------- Unit Tests Folder
..Test.Meek ------------------------------------------- Meek Unit Test
..Test.Meek.Business ---------------------------------- Meek.Business Unit Test
..Test.Meek.Data -------------------------------------- Meek.Data Unit Test
..Test.Meek.Forms ------------------------------------- Meek.Forms Unit Test
..Test.Meek.Presentation ------------------------------ Meek.Presentation Unit Test
..Test.Meek.Web --------------------------------------- Meek.Web Unit Test
..Test.Meek.Web.Mvc ----------------------------------- Meek.Web.Mvc Unit Test
README ------------------------------------------------ README Document
README.md --------------------------------------------- README Mark Down
License ----------------------------------------------- License File

2.2 Solution Files

The Meek Project Solutions are located in folder 1Solution

001.Meek.Framework.sln -------------------------------- Meek Library Solution
002.Meek.Data.sln ------------------------------------- Meek.Data Solution (Data Plugins are included in the solution)
003.Meek.Business.sln --------------------------------- Meek.Business Solution
004.Meek.Presentation.sln ----------------------------- Meek.Presentation Solution
005.Meek.Forms.sln ------------------------------------ Meek.Forms Solution
006.Meek.Web.sln -------------------------------------- Meek.Web Solution
900.Meek.Test.sln ------------------------------------- Meek Unit Tests Solution

The Solutions are numbered according to its referencing heirarchy, when building the source you need to build
according to its heirarchy.

3. Building the Source
--------------------------------------------------------------------------------------------------
3.1 Building Manually
(See section 2.2 for more details)


3.2 Building with MS-Build using NAnt Build Scripts

Under the folder 1Build there are 2 batch files which would initiate a build when executed

Debug.Build.bat --------------------------------------- Will build Meek in Debug Mode
Release.Build.bat ------------------------------------- Will build Meek in Release Mode

The output of the build will be under the folder 1Build\Build

1Build\Build ------------------------------------------ Build Output Folder


4. License
--------------------------------------------------------------------------------------------------
4.1 Microsoft Public License (Ms-PL)

This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.

1. Definitions

The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.

A "contribution" is the original software, or any additions or changes to the software.

A "contributor" is any person that distributes its contribution under this license.

"Licensed patents" are a contributor's patent claims that read directly on its contribution.

2. Grant of Rights

(A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.

(B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.

3. Conditions and Limitations

(A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.

(B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.

(C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.

(D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.

(E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.