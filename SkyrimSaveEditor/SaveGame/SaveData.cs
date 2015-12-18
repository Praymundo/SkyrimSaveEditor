using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SkyrimSaveEditor.SaveGame
{
    public class SaveData
    {
        /*
        magic	char[13]	Constant: "TESV_SAVEGAME"
        headerSize	uint32	Size of the header.
        header	Header	
        screenshotData	uint8[3*shotWidth*shotHeight]	RGB pixel data of the image.
        formVersion	uint8	current as of Skyrim 1.9 is 74.
        pluginInfoSize	uint32	Size of the plugin information.
        pluginInfo	Plugin Info	
        fileLocationTable	File Location Table	
        globalDataTable1	Global Data[fileLocationTable.globalDataTable1Count]	Types 0 to 8.
        globalDataTable2	Global Data[fileLocationTable.globalDataTable2Count]	Types 100 to 114.
        changeForms	Change Form[fileLocationTable.changeFormCount]	
        globalDataTable3	Global Data[fileLocationTable.globalDataTable3Count]	Types 1000 to 1005.
        formIDArrayCount	uint32	
        formIDArray	formID[formIDArrayCount]	
        visitedWorldspaceArrayCount	uint32	
        visitedWorldspaceArray	formID[visitedWorldspaceArrayCount]	A list of the FormIDs of all worldspaces visited by the player.
        unknown3TableSize	uint32	Size in bytes of unknown3Table.
        unknown3Table	Unknown 3 Table	
        */

        public string GameSave { get; private set; }
        public int HeaderSize { get; private set; }
        public HeaderData Header { get; private set; }
        public Bitmap ScreenShot { get; private set; }
        public int FormVersion { get; private set; }
        public int PluginInfoSize { get; private set; }
        public PluginInfoData PluginInfo { get; private set; }
        public FileLocationTableData FileLocationTable{ get; private set; }
        public List<GlobalDataTableData> GlobalDataTable1 { get; private set; }
        public List<GlobalDataTableData> GlobalDataTable2 { get; private set; }
        public List<ChangeFormData> ChangeForm { get; private set; }
        public List<GlobalDataTableData> GlobalDataTable3 { get; private set; }
        public int FormIdArrayCount { get; private set; }
        public List<FormIdData> FormIdArray { get; private set; }
        public int VisitedWorldSpaceArrayCount { get; private set; }
        public List<FormIdData> VisitedWorldSpaceArray { get; private set; }
        public int Unknown3TableSize { get; private set; }
        public Unknown3TableData Unknown3Table { get; private set; }

        public SaveData()
        {
            
        }

    }
}
