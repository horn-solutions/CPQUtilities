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

    
}
