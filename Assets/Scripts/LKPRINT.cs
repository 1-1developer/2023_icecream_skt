using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

// SEWOO Windows ADK Version 2.0.0 
namespace LKCSTest
{
    #region LKPrint class declaration
    public class LKPrint
    {        
        //Dll file name.
        public const string SEWOODIR = "LKPOSTOT.dll";

        public LKPrint() { }

        #region Method Declaration
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "OpenPort")]
        public static extern Int32 OpenPort(string PortName, Int32 BaudRate);
        
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "ClosePort")]
        public static extern Int32 ClosePort();
        
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintBitmap")]
        public static extern Int32 PrintBitmap(string BitmapFile, Int32 Alignment, Int32 Options, Int32 Brightness, Int32 ImageMode);
        
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintString")]
        public static extern Int32 PrintString(string Data);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintBarCode")]
        public static extern Int32 PrintBarCode(string Data, Int32 Symbology, Int32 Height, Int32 Width, Int32 Alignment, Int32 TextPosition);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrinterSts")]
        public static extern Int32 PrinterSts();

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "OpenDrawer")]
        public static extern Int32 OpenDrawer(Int32 DrawerPinNum, Int32 PulseOnTime, Int32 PulseOffTime);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "DrawerSts")]
        public static extern Int32 DrawerSts();
                
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "CutPaper")]
        public static extern Int32 CutPaper();

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintText")]
        public static extern Int32 PrintText(string Data, Int32 Alignment, Int32 Options, Int32 TextSize);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintNormal")]
        public static extern Int32 PrintNormal(string Data);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintStart")]
        public static extern Int32 PrintStart();

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintStop")]
        public static extern Int32 PrintStop();

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintData")]
        public static extern Int32 PrintData(string Data, Int32 Size);

        // Page Mode Function.
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SetPageMode")]
        public static extern Int32 SetPageMode(bool IsPageMode);
        
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SetPrintDirection")]
        public static extern Int32 SetPrintDirection(Int32 pDirect);
        
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SetPrintingArea")]
        public static extern Int32 SetPrintingArea(Int32 PageHeight);
        
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SetAbsoluteVertical")]
        public static extern Int32 SetAbsoluteVertical(Int32 AbsolutePosition);
        
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SetRelativeVertical")]
        public static extern Int32 SetRelativeVertical(Int32 RelativePosition);
        // end Page Mode Function

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintText2Image")]
        public static extern Int32 PrintText2Image(string FontName, Int32 FontStyle, Int32 FontDotSize, string TextData, Int32 ReversePrint);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintText2ImageAlignment")]
        public static extern Int32 PrintText2ImageAlignment(string FontName, Int32 FontStyle, Int32 FontDotSize, string TextData, Int32 ReversePrint, Int32 Alignment);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "LineFeed")]
        public static extern Int32 LineFeed(Int32 LFCount);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "OutputCompletePrinting")]
        public static extern Int32 OutputCompletePrinting(Int32 TimeDelay);

        // Printing QRCode BarCode Function.
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintQRCode")]
        public static extern Int32 PrintQRCode(string Data, Int32 Size, Int32 ModuleSize, Int32 ECLevel, Int32 Alignment);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "MakeQRCodeBitmap")]
        public static extern Int32 MakeQRCodeBitmap(string Data, Int32 Size, Int32 ModuleSize, Int32 ECLevel, Int32 Version, Int32 MaskPattern, string BitmapName);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintQRCodeGenerator")]
        public static extern Int32 PrintQRCodeGenerator(string Data, Int32 Size, Int32 ModuleSize, Int32 ECLevel, Int32 Version, Int32 MaskPattern, Int32 Alignment);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintQRCodeFromFile")]
        public static extern Int32 PrintQRCodeFromFile(string File4QR, Int32 ModuleSize, Int32 ECLevel, Int32 Version, Int32 MaskPattern, Int32 Alignment);

        // Printing PDF417 BarCode Function
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintPDF417")]
        public static extern Int32 PrintPDF417(string PdfData, Int32 DataLength, Int32 NumberOfColumns, Int32 CellWidth, Int32 Alignment);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SaveNVBitmap")]
        public static extern Int32 SaveNVBitmap(string SaveBitmapNameList, Int32 Brightness, Int32 ImageMode);
        
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "DeleteNVBitmap")]
        public static extern Int32 DeleteNVBitmap();

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SetMasterUnit")]
        public static extern Int32 SetMasterUnit(Int32 UnitMeasure);
        
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintingWidth")]
        public static extern Int32 PrintingWidth(Int32 pwidth);
                
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "BlackMarkON")]
        public static extern Int32 BlackMarkON(Int32 FeedValue);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "BlackMarkSearch")]
        public static extern Int32 BlackMarkSearch();

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SetLabelSize")]
        public static extern Int32 SetLabelSize(Int32 widthsize, Int32 heightsize);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintLabel")]
        public static extern Int32 PrintLabel();

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintTTFXY")]
        public static extern Int32 PrintTTFXY(Int32 BaseUnitX, Int32 BaseUnitY, string FontName, Int32 FontStyle, Int32 FontDotSize, string TextData, Int32 ReversePrint);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintBitmapXY")]
        public static extern Int32 PrintBitmapXY(Int32 BaseUnitX, Int32 BaseUnitY, string BitmapFile);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintQRCodeXY")]
        public static extern Int32 PrintQRCodeXY(Int32 BaseUnitX, Int32 BaseUnitY, string Data, Int32 Size, Int32 ModuleSize, Int32 ECLevel, Int32 Version, Int32 MaskPattern);
        
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintTTFAlign")]
        public static extern Int32 PrintTTFAlign(Int32 Alignment, Int32 BaseUnitY, string FontName, Int32 FontStyle, Int32 FontDotSize, string TextData, Int32 ReversePrint);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintBitmapAlign")]
        public static extern Int32 PrintBitmapAlign(Int32 BaseUnitX, Int32 BaseUnitY, string BitmapFile);
        
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintQRCodeAlign")]
        public static extern Int32 PrintQRCodeAlign(Int32 Alignment, Int32 BaseUnitY, string data, Int32 Size, Int32 ModuleSize, Int32 ECLevel, Int32 Version, Int32 MaskPattern);
        
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintTextLS")]
        public static extern Int32 PrintTextLS(string Data, Int32 Alignment, Int32 Options, Int32 TextSize, Int32 LineSpacing);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "FeedDot")]
        public static extern Int32 FeedDot(Int32 dotvalue);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SetAlignment")]
        public static extern Int32 SetAlignment(Int32 Alignment);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SetMagnify")]
        public static extern Int32 SetMagnify(Int32 WidthandHeight);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SetAttribute")]
        public static extern Int32 SetAttribute(Int32 WidthandHeight);
        
        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SendCommand")]
        public static extern Int32 SendCommand(IntPtr Cmd, Int32 size);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "ReadData")]
        public static extern Int32 ReadData(out IntPtr ReadBuf, Int32 millisecond);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SetEncoding")]
        public static extern Int32 SetEncoding(Int32 iEncoding);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "Rotation")]
        public static extern Int32 Rotation(Int32 pRotate);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SetAbsoluteHorizontal")]
        public static extern Int32 SetAbsoluteHorizontal(Int32 AbsolutePosition);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SetMoveToXY")]
        public static extern Int32 SetMoveToXY(Int32 AbsoluteXPosition, Int32 AbsoluteYPosition);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "GetFeedStatus")]
        public static extern Int32 GetFeedStatus();

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintDirectCommand")]
        public static extern IntPtr PrintDirectCommand(string Data);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "SetTransactionMode")]
        public static extern Int32 SetTransactionMode(bool isFlag);

        [DllImport(SEWOODIR, SetLastError = true, EntryPoint = "PrintTransactionMode")]
        public static extern Int32 PrintTransactionMode();

        #endregion

        #region Constant Declaration
        //Method return value
        public const Int32 LK_SUCCESS = 0;
        public const Int32 LK_CREATE_ERROR = 1;
        public const Int32 LK_NOT_OPENED = 2;
        public const Int32 LK_TIMEOUT = -1;
        
        // Printer Status flag
        // Printer Status flag
        public const Int32 LK_STS_NORMAL = 0;
        public const Int32 LK_STS_COVEROPEN = 1;
        public const Int32 LK_STS_PAPERNEAREMPTY = 2;
        public const Int32 LK_STS_PAPEREMPTY = 4;
        public const Int32 LK_STS_POWEROFF = 8;

        // Cash Drawer Status flag
        public const Int32 LK_CD_STS_CLOSED = 0;
        public const Int32 LK_CD_STS_OPENED = 1;

        // Cash Drawer Kick-out Connector Pin
        public const Int32 LK_CD_PIN_TWO = 2;
        public const Int32 LK_CD_PIN_FIVE = 5;

        // Alignment Code
        public const Int32 LK_ALIGNMENT_LEFT = 0;
        public const Int32 LK_ALIGNMENT_CENTER = 1;
        public const Int32 LK_ALIGNMENT_RIGHT = 2;

        // Bitmap Size
        public const Int32 LK_BITMAP_NORMAL = 0;
        public const Int32 LK_BITMAP_WIDTH_DOUBLE = 1;
        public const Int32 LK_BITMAP_HEIGHT_DOUBLE = 2;
        public const Int32 LK_BITMAP_WIDTH_HEIGHT_DOUBLE = 3;

        // Bitmap Image Mode
        public const Int32 LK_BITMAP_NO_DITHER = 0;
        public const Int32 LK_BITMAP_ERROR_DIFFUSION = 1;
        public const Int32 LK_BITMAP_ORDERED_DITHER = 2;

        //Text Attribute
        //Font Attribute default value : not Bold, FontA, not Underline, not reverse
        public const Int32 LK_FNT_DEFAULT = 0;
        public const Int32 LK_FNT_FONTB = 1;
        public const Int32 LK_FNT_BOLD = 8;
        public const Int32 LK_FNT_UNDERLINE = 128;

        // Text Size Attribute
        public const Int32 LK_TXT_1WIDTH = 0;
        public const Int32 LK_TXT_2WIDTH = 16;
        public const Int32 LK_TXT_3WIDTH = 32;
        public const Int32 LK_TXT_4WIDTH = 48;
        public const Int32 LK_TXT_5WIDTH = 64;
        public const Int32 LK_TXT_6WIDTH = 80;
        public const Int32 LK_TXT_7WIDTH = 96;
        public const Int32 LK_TXT_8WIDTH = 112;

        public const Int32 LK_TXT_1HEIGHT = 0;
        public const Int32 LK_TXT_2HEIGHT = 1;
        public const Int32 LK_TXT_3HEIGHT = 2;
        public const Int32 LK_TXT_4HEIGHT = 3;
        public const Int32 LK_TXT_5HEIGHT = 4;
        public const Int32 LK_TXT_6HEIGHT = 5;
        public const Int32 LK_TXT_7HEIGHT = 6;
        public const Int32 LK_TXT_8HEIGHT = 7;

        // Barcode
        public const Int32 LK_BCS_PDF417 = 200;
        public const Int32 LK_BCS_MAXICODE = 201;
        public const Int32 LK_BCS_QRCODE = 202;

        public const Int32 LK_BCS_UPCA = 101;
        public const Int32 LK_BCS_UPCE = 102;
        public const Int32 LK_BCS_EAN8 = 103;
        public const Int32 LK_BCS_EAN13 = 104;
        public const Int32 LK_BCS_JAN8 = 105;
        public const Int32 LK_BCS_JAN13 = 106;
        public const Int32 LK_BCS_ITF = 107;
        public const Int32 LK_BCS_Codabar = 108;
        public const Int32 LK_BCS_Code39 = 109;
        public const Int32 LK_BCS_Code93 = 110;
        public const Int32 LK_BCS_Code128 = 111;
        
        // Barcode text position
        public const Int32 LK_HRI_TEXT_NONE = 0;
        public const Int32 LK_HRI_TEXT_ABOVE = 1;
        public const Int32 LK_HRI_TEXT_BELOW = 2;

        // True-Type Font Style
        public const Int32 LK_TTF_THIN = 0;
        public const Int32 LK_TTF_NORMAL = 1;
        public const Int32 LK_TTF_BOLD = 2;
        public const Int32 LK_TTF_ITALIC = 0x10;
        public const Int32 LK_TTF_UNDERLINE = 0x20;

        // True-Type Font Reverse Print
        public const Int32 LK_TTF_REVERSE_NO = 0;
        public const Int32 LK_TTF_REVERSE_YES = 1;

        // QRCode Error Correction Level.
        public const Int32 LK_QRCODE_EC_LEVEL_L = 0;
        public const Int32 LK_QRCODE_EC_LEVEL_M = 1;
        public const Int32 LK_QRCODE_EC_LEVEL_Q = 2;
        public const Int32 LK_QRCODE_EC_LEVEL_H = 3;

        // QRCode mask pattern.
        public const Int32 LK_QRCODE_MASK_AUTO = -1;
        public const Int32 LK_QRCODE_MASK_0	= 0;
        public const Int32 LK_QRCODE_MASK_1 = 1;
        public const Int32 LK_QRCODE_MASK_2	= 2;
        public const Int32 LK_QRCODE_MASK_3	= 3;
        public const Int32 LK_QRCODE_MASK_4	= 4;
        public const Int32 LK_QRCODE_MASK_5	= 5;
        public const Int32 LK_QRCODE_MASK_6	= 6;
        public const Int32 LK_QRCODE_MASK_7	= 7;

        // QRCode Symbol version.
        public const Int32 LK_QRCODE_VERSION_00	= 0; // Auto.
        public const Int32 LK_QRCODE_VERSION_01	= 1; // Version 1
        public const Int32 LK_QRCODE_VERSION_02	= 2; // Version 2
        public const Int32 LK_QRCODE_VERSION_03	= 3; // Version 3
        public const Int32 LK_QRCODE_VERSION_04	= 4; // Version 4
        public const Int32 LK_QRCODE_VERSION_05	= 5; // Version 5
        public const Int32 LK_QRCODE_VERSION_06	= 6; // Version 6
        public const Int32 LK_QRCODE_VERSION_07	= 7; // Version 7
        public const Int32 LK_QRCODE_VERSION_08	= 8; // Version 8
        public const Int32 LK_QRCODE_VERSION_09	= 9; // Version 9
        public const Int32 LK_QRCODE_VERSION_10	= 10; // Version 10
        public const Int32 LK_QRCODE_VERSION_11	= 11; // Version 11
        public const Int32 LK_QRCODE_VERSION_12	= 12; // Version 12
        public const Int32 LK_QRCODE_VERSION_13	= 13; // Version 13
        public const Int32 LK_QRCODE_VERSION_14	= 14; // Version 14
        public const Int32 LK_QRCODE_VERSION_15	= 15; // Version 15
        public const Int32 LK_QRCODE_VERSION_16	= 16; // Version 16
        public const Int32 LK_QRCODE_VERSION_17	= 17; // Version 17
        public const Int32 LK_QRCODE_VERSION_18	= 18; // Version 18
        public const Int32 LK_QRCODE_VERSION_19	= 19; // Version 19
        public const Int32 LK_QRCODE_VERSION_20 = 20; // Version 20
        public const Int32 LK_QRCODE_VERSION_21	= 21; // Version 21
        public const Int32 LK_QRCODE_VERSION_22	= 22; // Version 22
        public const Int32 LK_QRCODE_VERSION_23	= 23; // Version 23
        public const Int32 LK_QRCODE_VERSION_24	= 24; // Version 24
        public const Int32 LK_QRCODE_VERSION_25	= 25; // Version 25
        public const Int32 LK_QRCODE_VERSION_26	= 26; // Version 26
        public const Int32 LK_QRCODE_VERSION_27	= 27; // Version 27
        public const Int32 LK_QRCODE_VERSION_28	= 28; // Version 28
        public const Int32 LK_QRCODE_VERSION_29	= 29; // Version 29
        public const Int32 LK_QRCODE_VERSION_30	= 30; // Version 30
        public const Int32 LK_QRCODE_VERSION_31	= 31; // Version 31
        public const Int32 LK_QRCODE_VERSION_32	= 32; // Version 32
        public const Int32 LK_QRCODE_VERSION_33	= 33; // Version 33
        public const Int32 LK_QRCODE_VERSION_34	= 34; // Version 34
        public const Int32 LK_QRCODE_VERSION_35	= 35; // Version 35
        public const Int32 LK_QRCODE_VERSION_36	= 36; // Version 36
        public const Int32 LK_QRCODE_VERSION_37	= 37; // Version 37
        public const Int32 LK_QRCODE_VERSION_38	= 38; // Version 38
        public const Int32 LK_QRCODE_VERSION_39	= 39; // Version 39
        public const Int32 LK_QRCODE_VERSION_40	= 40; // Version 40
        #endregion
    }
    #endregion
}
