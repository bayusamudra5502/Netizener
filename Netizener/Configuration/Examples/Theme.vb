Imports System.Linq
Imports System.IO
Imports System.Drawing

Module Theme

	<Serializable>
	Class Extension
		Property Extention As String
		Property ExtentionName As String
		Property Type As FileTypes
		Property IsExecutable As Boolean
		Property Icon As Bitmap
		Property Theme As Themes
		Property OpenText As String
		Property AdvancedDll As String

		<Serializable>
		Enum FileTypes
			Document
			Audio
			Video
			Program
			System
			Picture
			Archive
			Font
			Other
		End Enum

		<Serializable>
		Structure Themes
			Dim Name As String
			Dim DesignBy As String
			Dim Developer As String
			Dim InputDate As Date
		End Structure
	End Class

	Function GetBitmap(Name As String) As Bitmap
		Dim path As String = IO.Path.Combine("C:\Users\Bayu\Downloads\FILE EXTENSION\File", Name & ".png")
		Return New Bitmap(path)
	End Function

	Sub Start()
		Dim Conf As New List(Of Extension)
		Dim Tema As Extension.Themes

		Tema.Name = "Default"
		Tema.DesignBy = "FlatIcon"
		Tema.Developer = "PATCH"
		Tema.InputDate = Now()

		'3D
		Conf.Add(New Extension With {.Extention = ".stl",
					.Type = Extension.FileTypes.Other,
					.ExtentionName = "Stereo Lithographic Data Format",
					.Icon = GetBitmap("3d"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".obj",
					.Type = Extension.FileTypes.Other,
					.ExtentionName = "Wavefront File",
					.Icon = GetBitmap("3d"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".fbx",
					.Type = Extension.FileTypes.Other,
					.ExtentionName = "Autodesk Flimbox File",
					.Icon = GetBitmap("3d"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".dae",
					.Type = Extension.FileTypes.Other,
					.ExtentionName = "COLLADA File",
					.Icon = GetBitmap("3d"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".iges",
					.Type = Extension.FileTypes.Other,
					.ExtentionName = "Initial Graphics Exchange Specification",
					.Icon = GetBitmap("3d"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".step",
					.Type = Extension.FileTypes.Other,
					.ExtentionName = "Standard for the Exchange of Product Model Data File",
					.Icon = GetBitmap("3d"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".vrml",
					.Type = Extension.FileTypes.Other,
					.ExtentionName = "Virtual Reality Modeling Language File",
					.Icon = GetBitmap("3d"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".x3d",
					.Type = Extension.FileTypes.Other,
					.ExtentionName = "Scene description languages File",
					.Icon = GetBitmap("3d"), .IsExecutable = False, .Theme = Tema})

		'3ds
		Conf.Add(New Extension With {.Extention = ".3ds",
					.Type = Extension.FileTypes.Other,
					.ExtentionName = "Legacy 3D Studio Model File",
					.Icon = GetBitmap("3ds"), .IsExecutable = False, .Theme = Tema})

		'aac
		Conf.Add(New Extension With {.Extention = ".aac",
					.Type = Extension.FileTypes.Audio,
					.ExtentionName = "Advanced Audio Coding",
					.Icon = GetBitmap("aac"), .IsExecutable = False, .Theme = Tema})

		'ai
		Conf.Add(New Extension With {.Extention = ".ai",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Adobe Illustrator File",
					.Icon = GetBitmap("ai"), .IsExecutable = False, .Theme = Tema})

		'avi
		Conf.Add(New Extension With {.Extention = ".avi",
					.Type = Extension.FileTypes.Video,
					.ExtentionName = "Audio Video Interleave",
					.Icon = GetBitmap("avi"), .IsExecutable = False, .Theme = Tema})

		'bmp
		Conf.Add(New Extension With {.Extention = ".bmp",
					.Type = Extension.FileTypes.Picture,
					.ExtentionName = "Bitmap formatted image",
					.Icon = GetBitmap("bmp"), .IsExecutable = False, .Theme = Tema})
		'cad
		Conf.Add(New Extension With {.Extention = ".cad",
					.Type = Extension.FileTypes.Other,
					.ExtentionName = "BobCAD-CAM File",
					.Icon = GetBitmap("cad"), .IsExecutable = False, .Theme = Tema})
		'cdr
		Conf.Add(New Extension With {.Extention = ".cdr",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "CorelDraw File",
					.Icon = GetBitmap("cdr"), .IsExecutable = False, .Theme = Tema})

		'css
		Conf.Add(New Extension With {.Extention = ".css",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Cascading Style Sheets Source File",
					.Icon = GetBitmap("css"), .IsExecutable = False, .Theme = Tema})

		'dat
		Conf.Add(New Extension With {.Extention = ".dat",
					.Type = Extension.FileTypes.Other,
					.ExtentionName = "DAT File Format",
					.Icon = GetBitmap("dat"), .IsExecutable = False, .Theme = Tema})

		'dbf
		Conf.Add(New Extension With {.Extention = ".dbf",
					.Type = Extension.FileTypes.System,
					.ExtentionName = "Database File Format",
					.Icon = GetBitmap("dbf"), .IsExecutable = False, .Theme = Tema})

		'database
		Conf.Add(New Extension With {.Extention = ".db",
					.Type = Extension.FileTypes.System,
					.ExtentionName = "Database File",
					.Icon = GetBitmap("database"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".sqlite",
					.Type = Extension.FileTypes.System,
					.ExtentionName = "SQLite Database File",
					.Icon = GetBitmap("database"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".sqlite3",
					.Type = Extension.FileTypes.System,
					.ExtentionName = "SQLite 3 Database File",
					.Icon = GetBitmap("database"), .IsExecutable = False, .Theme = Tema})

		'dll
		Conf.Add(New Extension With {.Extention = ".dll",
					.Type = Extension.FileTypes.System,
					.ExtentionName = "Dynamic Link Library",
					.Icon = GetBitmap("dll"), .IsExecutable = False, .Theme = Tema})

		'dmg
		Conf.Add(New Extension With {.Extention = ".dmg",
					.Type = Extension.FileTypes.Archive,
					.ExtentionName = "Mac OS X Disk Image",
					.Icon = GetBitmap("dmg"), .IsExecutable = False, .Theme = Tema})

		'doc
		Conf.Add(New Extension With {.Extention = ".doc",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Microsoft Word document",
					.Icon = GetBitmap("doc"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".docm",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Microsoft Word macro-enabled document",
					.Icon = GetBitmap("doc"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".docx",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Microsoft Word document",
					.Icon = GetBitmap("doc"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".dot",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Microsoft Word document template",
					.Icon = GetBitmap("doc"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".dotx",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Office Open XML text document template",
					.Icon = GetBitmap("doc"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".odt",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "OpenDocument text document",
					.Icon = GetBitmap("doc"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".ott",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "OpenDocument text document template",
					.Icon = GetBitmap("doc"), .IsExecutable = False, .Theme = Tema})

		'dwg
		Conf.Add(New Extension With {.Extention = ".doc",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "AutoCAD Drawing Database File",
					.Icon = GetBitmap("dwg"), .IsExecutable = False, .Theme = Tema})

		'dxf
		Conf.Add(New Extension With {.Extention = ".dxf",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Drawing Exchange Format File",
					.Icon = GetBitmap("dxf"), .IsExecutable = False, .Theme = Tema})

		'eps
		Conf.Add(New Extension With {.Extention = ".eps",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Encapsulated PostScript File",
					.Icon = GetBitmap("eps"), .IsExecutable = False, .Theme = Tema})

		'exe
		Conf.Add(New Extension With {.Extention = ".exe",
					.Type = Extension.FileTypes.Program,
					.ExtentionName = "Microsoft Windows Executable File",
					.Icon = GetBitmap("exe"), .IsExecutable = True, .Theme = Tema})

		'cmd
		Conf.Add(New Extension With {.Extention = ".sh",
					.Type = Extension.FileTypes.Program,
					.ExtentionName = "Bash Shell Script",
					.Icon = GetBitmap("cmd"), .IsExecutable = True, .Theme = Tema, .OpenText = "Run Shell Script", .AdvancedDll = "shell.dll"})

		Conf.Add(New Extension With {.Extention = ".bat",
					.Type = Extension.FileTypes.Program,
					.ExtentionName = "Batch File",
					.Icon = GetBitmap("cmd"), .IsExecutable = True, .Theme = Tema, .OpenText = "Run Batch File", .AdvancedDll = "bat.dll"})

		Conf.Add(New Extension With {.Extention = ".cmd",
					.Type = Extension.FileTypes.Program,
					.ExtentionName = "Windows Command File",
					.Icon = GetBitmap("cmd"), .IsExecutable = True, .Theme = Tema, .OpenText = "Run Command File", .AdvancedDll = "cmd.dll"})

		Conf.Add(New Extension With {.Extention = ".com",
					.Type = Extension.FileTypes.Program,
					.ExtentionName = "DOS Command File",
					.Icon = GetBitmap("cmd"), .IsExecutable = True, .Theme = Tema, .OpenText = "Run Command File", .AdvancedDll = "com.dll"})

		'Default
		Conf.Add(New Extension With {.Extention = "Default",
					.Type = Extension.FileTypes.Other,
					.ExtentionName = "File",
					.Icon = GetBitmap("file"), .IsExecutable = False, .Theme = Tema})

		'fla
		Conf.Add(New Extension With {.Extention = ".fla",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Adobe Animate Animation File",
					.Icon = GetBitmap("fla"), .IsExecutable = False, .Theme = Tema})

		'flv
		Conf.Add(New Extension With {.Extention = ".flv",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Animate Video File",
					.Icon = GetBitmap("flv"), .IsExecutable = False, .Theme = Tema})

		'font
		Conf.Add(New Extension With {.Extention = ".afm",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "Adobe Font Metrics",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".bdf",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "Bitmap Distribution Format",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".bmf",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "ByteMap Font Format",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".fnt",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "Graphics Environment Manager (GEM) Bitmapped Font",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".fon",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "Microsoft Windows Bitmapped Font",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema, .OpenText = "Install Font", .AdvancedDll = "FontInstall.fon.dll"})

		Conf.Add(New Extension With {.Extention = ".mgf",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "OpenType Font",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".otf",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "Adobe Font Metrics",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema, .OpenText = "Install Font", .AdvancedDll = "FontInstall.otf.dll"})

		Conf.Add(New Extension With {.Extention = ".pcf",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "Portable Compiled Format",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".pfa",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "Printer Font ASCII",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".pfb",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "Adobe Printer Font Binary",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".pfm",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "Adobe Printer Font Metrics",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".fond",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "Mac Os Font Description resource",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".sfd",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "FontForge spline font database Font",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".snf",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "Server Normal Format",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".snf",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "Server Normal Format",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".tdf",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "TheDraw Font",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".tfm",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "TeX font metric",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".ttf",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "TrueType Font",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema, .OpenText = "Install Font", .AdvancedDll = "FontInstall.ttf.dll"})

		Conf.Add(New Extension With {.Extention = ".ttc",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "TrueType Font",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema, .OpenText = "Install Font", .AdvancedDll = "FontInstall.ttc.dll"})
		'
		Conf.Add(New Extension With {.Extention = ".woff",
					.Type = Extension.FileTypes.Font,
					.ExtentionName = "Web Open Font Format",
					.Icon = GetBitmap("font"), .IsExecutable = False, .Theme = Tema})

		'tif
		Conf.Add(New Extension With {.Extention = ".tif",
					.Type = Extension.FileTypes.Picture,
					.ExtentionName = "Tagged Image File Format",
					.Icon = GetBitmap("tif"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".tiff",
					.Type = Extension.FileTypes.Picture,
					.ExtentionName = "Tagged Image File Format",
					.Icon = GetBitmap("tif"), .IsExecutable = False, .Theme = Tema})

		'gif
		Conf.Add(New Extension With {.Extention = ".gif",
					.Type = Extension.FileTypes.Picture,
					.ExtentionName = "Adobe Font Metrics",
					.Icon = GetBitmap("gif"), .IsExecutable = False, .Theme = Tema})

		'html
		Conf.Add(New Extension With {.Extention = ".html",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Hypertext Markup Language Source File",
					.Icon = GetBitmap("html"), .IsExecutable = False, .Theme = Tema})

		'indd
		Conf.Add(New Extension With {.Extention = ".indd",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Adobe InDesign Document",
					.Icon = GetBitmap("indd"), .IsExecutable = False, .Theme = Tema})

		'Javascript
		Conf.Add(New Extension With {.Extention = ".js",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "JavaScript Source Code",
					.Icon = GetBitmap("js"), .IsExecutable = False, .Theme = Tema, .OpenText = "Run with Node.JS", .AdvancedDll = "NodeJs.dll"})

		Conf.Add(New Extension With {.Extention = ".ts",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "TypeScript Source Code",
					.Icon = GetBitmap("js"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".tsx",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "TypeScript Source Code",
					.Icon = GetBitmap("js"), .IsExecutable = False, .Theme = Tema})

		'jpg
		Conf.Add(New Extension With {.Extention = ".jpg",
					.Type = Extension.FileTypes.Picture,
					.ExtentionName = "Joint Photographic Experts Group Image File",
					.Icon = GetBitmap("jpg"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".jpeg",
					.Type = Extension.FileTypes.Picture,
					.ExtentionName = "Joint Photographic Experts Group Image File",
					.Icon = GetBitmap("jpg"), .IsExecutable = False, .Theme = Tema})

		'json
		Conf.Add(New Extension With {.Extention = ".json",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "JavaScript Object Notation",
					.Icon = GetBitmap("json"), .IsExecutable = False, .Theme = Tema})

		'max
		Conf.Add(New Extension With {.Extention = ".max",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "3ds Max Scene File",
					.Icon = GetBitmap("max"), .IsExecutable = False, .Theme = Tema})

		'mp3
		Conf.Add(New Extension With {.Extention = ".mp3",
					.Type = Extension.FileTypes.Audio,
					.ExtentionName = "Moving Picture Experts Group (MPEG) Layer 3 Audio File",
					.Icon = GetBitmap("mp3"), .IsExecutable = False, .Theme = Tema})

		'mpg
		Conf.Add(New Extension With {.Extention = ".mp1",
					.Type = Extension.FileTypes.Audio,
					.ExtentionName = "Moving Picture Experts Group (MPEG) Layer 1 Audio File",
					.Icon = GetBitmap("mpg"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".mp2",
					.Type = Extension.FileTypes.Audio,
					.ExtentionName = "Moving Picture Experts Group (MPEG) Layer 2 Audio File",
					.Icon = GetBitmap("mpg"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".mpg",
					.Type = Extension.FileTypes.Audio,
					.ExtentionName = "Moving Picture Experts Group (MPEG) Audio File",
					.Icon = GetBitmap("mpg"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".mpeg",
					.Type = Extension.FileTypes.Audio,
					.ExtentionName = "Moving Picture Experts Group (MPEG) Audio File",
					.Icon = GetBitmap("mpg"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".mpe",
					.Type = Extension.FileTypes.Audio,
					.ExtentionName = "Moving Picture Experts Group (MPEG) Audio File",
					.Icon = GetBitmap("mpg"), .IsExecutable = False, .Theme = Tema})

		'mp4
		Conf.Add(New Extension With {.Extention = ".mp4",
					.Type = Extension.FileTypes.Video,
					.ExtentionName = "Moving Picture Experts Group (MPEG) Layer 4 Video File",
					.Icon = GetBitmap("mp4"), .IsExecutable = False, .Theme = Tema})

		'music
		Conf.Add(New Extension With {.Extention = ".wav",
					.Type = Extension.FileTypes.Audio,
					.ExtentionName = "Waveform Audio File Format",
					.Icon = GetBitmap("music"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".aac",
					.Type = Extension.FileTypes.Audio,
					.ExtentionName = "Advanced Audio Coding",
					.Icon = GetBitmap("music"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".ape",
					.Type = Extension.FileTypes.Audio,
					.ExtentionName = "Monkey's Audio Lossless Audio File",
					.Icon = GetBitmap("music"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".ogg",
					.Type = Extension.FileTypes.Audio,
					.ExtentionName = "Ogg Vorbis Audio File",
					.Icon = GetBitmap("music"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".flac",
					.Type = Extension.FileTypes.Audio,
					.ExtentionName = "Free Lossless Audio Codec",
					.Icon = GetBitmap("music"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".pcm",
					.Type = Extension.FileTypes.Audio,
					.ExtentionName = "PCM Raw Data",
					.Icon = GetBitmap("music"), .IsExecutable = False, .Theme = Tema})

		'pdf
		Conf.Add(New Extension With {.Extention = ".pdf",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Portable Document Format File",
					.Icon = GetBitmap("pdf"), .IsExecutable = False, .Theme = Tema})

		'php
		Conf.Add(New Extension With {.Extention = ".php",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Hypertext Preprocessor (PHP) Source Code File",
					.Icon = GetBitmap("php"), .IsExecutable = False, .Theme = Tema})

		'png
		Conf.Add(New Extension With {.Extention = ".png",
					.Type = Extension.FileTypes.Picture,
					.ExtentionName = "Portable Network Graphic",
					.Icon = GetBitmap("png"), .IsExecutable = False, .Theme = Tema})

		'ppt
		Conf.Add(New Extension With {.Extention = ".pot",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Microsoft PowerPoint template",
					.Icon = GetBitmap("ppt"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".pps",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Microsoft PowerPoint Show",
					.Icon = GetBitmap("ppt"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".ppt",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Microsoft PowerPoint Presentation",
					.Icon = GetBitmap("ppt"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".pptx",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Microsoft PowerPoint Presentation",
					.Icon = GetBitmap("ppt"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".odp",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "OpenDocument Presentation",
					.Icon = GetBitmap("ppt"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".otp",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "OpenDocument Presentation template",
					.Icon = GetBitmap("ppt"), .IsExecutable = False, .Theme = Tema})

		'ps
		Conf.Add(New Extension With {.Extention = ".ps",
					.Type = Extension.FileTypes.Picture,
					.ExtentionName = "PostScript File",
					.Icon = GetBitmap("ps"), .IsExecutable = False, .Theme = Tema})

		'psd
		Conf.Add(New Extension With {.Extention = ".psd",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Adobe Photoshop Document",
					.Icon = GetBitmap("psd"), .IsExecutable = False, .Theme = Tema})

		'qxd
		Conf.Add(New Extension With {.Extention = ".qxd",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "QuarkXPress Document",
					.Icon = GetBitmap("qxd"), .IsExecutable = False, .Theme = Tema})

		'raw
		Conf.Add(New Extension With {.Extention = ".raw",
					.Type = Extension.FileTypes.Other,
					.ExtentionName = "Raw File",
					.Icon = GetBitmap("raw"), .IsExecutable = False, .Theme = Tema})

		'rtf
		Conf.Add(New Extension With {.Extention = ".rtf",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Rich Text Format File",
					.Icon = GetBitmap("rtf"), .IsExecutable = False, .Theme = Tema})

		'sketch
		Conf.Add(New Extension With {.Extention = ".sketch",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Sketch Drawing",
					.Icon = GetBitmap("sketch"), .IsExecutable = False, .Theme = Tema})

		'sql
		Conf.Add(New Extension With {.Extention = ".sql",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Structured Query Language Data File",
					.Icon = GetBitmap("sql"), .IsExecutable = False, .Theme = Tema})

		'svg
		Conf.Add(New Extension With {.Extention = ".svg",
					.Type = Extension.FileTypes.Picture,
					.ExtentionName = "Scalable Vector Graphics File",
					.Icon = GetBitmap("svg"), .IsExecutable = False, .Theme = Tema})

		'txt 
		Conf.Add(New Extension With {.Extention = ".txt",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Plain Text File",
					.Icon = GetBitmap("txt"), .IsExecutable = False, .Theme = Tema})

		'wmv
		Conf.Add(New Extension With {.Extention = ".wmv",
					.Type = Extension.FileTypes.Video,
					.ExtentionName = "Windows Media Video File",
					.Icon = GetBitmap("wmv"), .IsExecutable = False, .Theme = Tema})

		'xls
		Conf.Add(New Extension With {.Extention = ".xlk",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Microsoft Excel Worksheet Backup",
					.Icon = GetBitmap("xls"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".xls",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Microsoft Excel Worksheet Sheet (97–2003)",
					.Icon = GetBitmap("xls"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".xlsb",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Microsoft Excel Binary Workbook",
					.Icon = GetBitmap("xls"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".xlsm",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Microsoft Excel Macro-Enabled Workbook",
					.Icon = GetBitmap("xls"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".xlsx",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Microsoft Excel Worksheet Sheet",
					.Icon = GetBitmap("xls"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".ods",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "OpenDocument Spreadsheet",
					.Icon = GetBitmap("xls"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".ots",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "OpenDocument Spreadsheet Template",
					.Icon = GetBitmap("xls"), .IsExecutable = False, .Theme = Tema})

		'XML
		Conf.Add(New Extension With {.Extention = ".xml",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Extensible Markup Language (XML) File",
					.Icon = GetBitmap("xml"), .IsExecutable = False, .Theme = Tema})

		'zip
		Conf.Add(New Extension With {.Extention = ".zip",
					.Type = Extension.FileTypes.Archive,
					.ExtentionName = "ZIP Archive File Format",
					.Icon = GetBitmap("zip"), .IsExecutable = False, .Theme = Tema})

		'zip-1
		Conf.Add(New Extension With {.Extention = ".7z",
					.Type = Extension.FileTypes.Archive,
					.ExtentionName = "7z Archive File Format",
					.Icon = GetBitmap("zip-1"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".tar.bz2",
					.Type = Extension.FileTypes.Archive,
					.ExtentionName = "TAR.BZ2 Archive File Format",
					.Icon = GetBitmap("zip-1"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".tar.gz",
					.Type = Extension.FileTypes.Archive,
					.ExtentionName = "TAR.GZ Archive File Format",
					.Icon = GetBitmap("zip-1"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".rar",
					.Type = Extension.FileTypes.Archive,
					.ExtentionName = "RAR Archive File Format",
					.Icon = GetBitmap("zip-1"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".zipx",
					.Type = Extension.FileTypes.Archive,
					.ExtentionName = "ZIPX Archive File Format",
					.Icon = GetBitmap("zip-1"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".tar",
					.Type = Extension.FileTypes.Archive,
					.ExtentionName = "TAR Archive File Format",
					.Icon = GetBitmap("zip-1"), .IsExecutable = False, .Theme = Tema})

		'cd
		Conf.Add(New Extension With {.Extention = ".wim",
					.Type = Extension.FileTypes.Archive,
					.ExtentionName = "Windows Imaging Format File",
					.Icon = GetBitmap("cd"), .IsExecutable = False, .Theme = Tema})

		'iso
		Conf.Add(New Extension With {.Extention = ".iso",
					.Type = Extension.FileTypes.Archive,
					.ExtentionName = "Disc Image File",
					.Icon = GetBitmap("iso"), .IsExecutable = False, .Theme = Tema})

		'cab
		Conf.Add(New Extension With {.Extention = ".cab",
					.Type = Extension.FileTypes.Archive,
					.ExtentionName = "Windows Cabinet File",
					.Icon = GetBitmap("cab"), .IsExecutable = False, .Theme = Tema})

		'movie
		Conf.Add(New Extension With {.Extention = ".mov",
					.Type = Extension.FileTypes.Video,
					.ExtentionName = "Apple QuickTime Movie",
					.Icon = GetBitmap("movie"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".3gp",
					.Type = Extension.FileTypes.Video,
					.ExtentionName = "3GPP Multimedia File",
					.Icon = GetBitmap("movie"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".asf",
					.Type = Extension.FileTypes.Video,
					.ExtentionName = "Advanced Systems Format File",
					.Icon = GetBitmap("movie"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".rm",
					.Type = Extension.FileTypes.Video,
					.ExtentionName = "RealMedia File",
					.Icon = GetBitmap("movie"), .IsExecutable = False, .Theme = Tema})

		'mkv
		Conf.Add(New Extension With {.Extention = ".mkv",
					.Type = Extension.FileTypes.Video,
					.ExtentionName = "Matroska Video File",
					.Icon = GetBitmap("mkv"), .IsExecutable = False, .Theme = Tema})

		'swf
		Conf.Add(New Extension With {.Extention = ".swf",
					.Type = Extension.FileTypes.Video,
					.ExtentionName = "Shockwave Flash Movie",
					.Icon = GetBitmap("swf"), .IsExecutable = False, .Theme = Tema})

		'camel
		Conf.Add(New Extension With {.Extention = ".pl",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Perl Script",
					.Icon = GetBitmap("camel"), .IsExecutable = False, .Theme = Tema})

		'vs
		Conf.Add(New Extension With {.Extention = ".vb",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Visual Basic Source Code",
					.Icon = GetBitmap("vs"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".vbs",
					.Type = Extension.FileTypes.Program,
					.ExtentionName = "Visual Basic Script File",
					.Icon = GetBitmap("vs"), .IsExecutable = True, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".vbproj",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Visual Basic Project",
					.Icon = GetBitmap("vs"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".sln",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Visual Studio Solution File",
					.Icon = GetBitmap("vs"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".csproj",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Visual Studio C# Project",
					.Icon = GetBitmap("vs"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".dbproj",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Visual Studio Database Project File",
					.Icon = GetBitmap("vs"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".fsproj",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Visual F# Project File",
					.Icon = GetBitmap("vs"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".sqlproj",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Visual Studio SQL Server Project",
					.Icon = GetBitmap("vs"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".vcproj",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Visual C++ Project File",
					.Icon = GetBitmap("vs"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".vsix",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Visual Studio Extention Installer",
					.Icon = GetBitmap("vs"), .IsExecutable = False, .Theme = Tema})

		'C
		Conf.Add(New Extension With {.Extention = ".c",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "C Source Code File",
					.Icon = GetBitmap("c"), .IsExecutable = False, .Theme = Tema})

		'cpp
		Conf.Add(New Extension With {.Extention = ".cpp",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "C++ Source Code File",
					.Icon = GetBitmap("cpp"), .IsExecutable = False, .Theme = Tema})

		'cs
		Conf.Add(New Extension With {.Extention = ".cs",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "C# Source Code File",
					.Icon = GetBitmap("cs"), .IsExecutable = False, .Theme = Tema})

		'py
		Conf.Add(New Extension With {.Extention = ".py",
					.Type = Extension.FileTypes.Program,
					.ExtentionName = "Python Script File",
					.Icon = GetBitmap("c"), .IsExecutable = True, .Theme = Tema, .OpenText = "Run Python Program", .AdvancedDll = "Python.dll"})

		'rb
		Conf.Add(New Extension With {.Extention = ".rb",
					.Type = Extension.FileTypes.Program,
					.ExtentionName = "Ruby Source Code",
					.Icon = GetBitmap("rb"), .IsExecutable = True, .Theme = Tema, .OpenText = "Run Ruby Program", .AdvancedDll = "Ruby.dll"})

		'swift
		Conf.Add(New Extension With {.Extention = ".swift",
					.Type = Extension.FileTypes.Document,
					.ExtentionName = "Swift Source Code File",
					.Icon = GetBitmap("rb"), .IsExecutable = False, .Theme = Tema})

		'java
		Conf.Add(New Extension With {.Extention = ".java",
					.Type = Extension.FileTypes.Program,
					.ExtentionName = "Java Source Code File",
					.Icon = GetBitmap("java"), .IsExecutable = False, .Theme = Tema})

		Conf.Add(New Extension With {.Extention = ".class",
					.Type = Extension.FileTypes.Program,
					.ExtentionName = "Java Class File",
					.Icon = GetBitmap("java"), .IsExecutable = True, .Theme = Tema, .OpenText = "Run Java Class", .AdvancedDll = "Java.dll"})

		Conf.Add(New Extension With {.Extention = ".jar",
					.Type = Extension.FileTypes.Program,
					.ExtentionName = "Java Archive File",
					.Icon = GetBitmap("java"), .IsExecutable = True, .Theme = Tema, .OpenText = "Run Java Executable", .AdvancedDll = "Java.Jar.dll"})

		'MAKE!!
		Dim Stream As FileStream = File.Create(Path.Combine("C:\Users\Bayu\Desktop", "Default.thm"))
		Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

		formatter.Serialize(Stream, Conf)

		Stream.Close()
	End Sub

	'Public Sub main()
	'Dim Stream As FileStream = File.Open(Path.Combine("C:\Users\Bayu\Desktop", "Extention.conf"), FileMode.Open)
	'Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
	'
	'Dim Conf As List(Of Extension) = CType(formatter.Deserialize(Stream), List(Of Extension))

	'Dim resulte As IEnumerable(Of Extension) = From data In Conf
	'											   Where data.Extention = ".fbx"
	'Select Case data
	'
	'Dim result As Extension = resulte.First()

	'	Console.WriteLine(result.ExtentionName)
	'	Console.WriteLine(result.Icon)
	'	Console.WriteLine(result.IsExecutable)
	'	Console.ReadKey()
	'End Sub


End Module
