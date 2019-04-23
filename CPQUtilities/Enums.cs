using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQUtilities
{

    public enum Actions
    {
        ADD,
        UPDATE,
        ADDORUPDATE,
        DELETE,
        GETLANGUAGES

    }

    public enum ProductDisplayType
    {
        Simple,
        Configurable,
        System,
        Collection,
        Parent_child
    }

    public enum ProductIdentificator
    {
        PartNumber,
        ProductName,
        ExternalId,
        CPQProductID
    }

    public enum ProductGlobalScriptsEventsEvent
    {
        OnProductLoaded,
        OnProductRuleExecutionStart,
        OnProductRuleExecutionEnd,
        OnProductTabChanged,
        OnProductCompleted,
        OnProductAddedToQuote,
        OnProductBeforeAddToQuote
    }

    public enum ProductAttributeDisplayType
    {
        Button,
        CheckBox,
        DisplayOnlyText,
        DropDown,
        FileAttachment,
        FreeInput_No_Matching,
        HiddenCalculated_No_Matching,
        FreeForm_ExactMatch_w_OtherwiseOption,
        FreeForm_ExactMatch,
        FreeForm_MatchLower,
        FreeForm_MatchUpper,
        FreeForm_SetMatchLower,
        FreeForm_SetMatchUpper,
        ImageButton,
        ListBox_MultiSelect,
        ListBox,
        RadioButton

    }

    public enum UPSShippingCodeType
    {
        //note: this may be outdated.
        //API help from http://help.webcomcpq.com/doku.php?id=appendixd:externalwebservice:upsshipping references https://www.ups.com/ups.app/xml/Rate ,
        //however https://www.ups.com/upsdeveloperkit?loc=en_US
        US_Domestic,
        US_Originating,
        Puerto_Rico_Originating,
        Canada_Originating,
        Mexico_Originating,
        Polish_Domestic,
        European_Union,
        Other_Originating,
        Freight_Shipments

    }

    
}
