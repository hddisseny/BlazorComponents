using Microsoft.AspNetCore.Components;

namespace BootzorComponents.Components.Dialog;

public partial class ZorDialog : ComponentBase
{

    [Parameter, EditorRequired]
    public RenderFragment Title { get; set; }

    /// <summary>
    /// Content of the modal
    /// </summary>
    [Parameter, EditorRequired]
    public RenderFragment? Content { get; set; } 

    /// <summary>
    /// Indicator if the Overlay has to appear
    /// true by default
    /// </summary>
    [Parameter]
    public bool Overlay { get; set; } = true;

    /// <summary>
    /// EventCallback<bool> to return the result 
    /// </summary>
    [Parameter, EditorRequired]
    public EventCallback<bool> ResultModal { get; set; }

    /// <summary>
    /// Type of the dialog to incate the number of buttons
    /// </summary>
    [Parameter, EditorRequired]
    public DialogTypes DialogType { get; set; }

    /// <summary>
    /// Position of the dialog
    /// DialogPosition.Bottom by default
    /// </summary>
    [Parameter]
    public DialogPosition Position { get; set; } = DialogPosition.Bottom;

    /// <summary>
    /// Callback al presionar el botón Ok, Delete
    /// </summary>
    /// <returns>Invoca al método pasado por parámetro</returns>
    private Task ClickDialogResult(bool result)
    {
        ShowDialog = false;
        return ResultModal.InvokeAsync(result);
    }

    /// <summary>
    /// Paramenter to indicate when show the dialog. 
    /// To use you need use @ref in the modal and use NameModal.ShhowModal = true | false
    /// </summary>
    [Parameter]
    public bool ShowDialog { get; set; } = false;

    /// <summary>
    /// Collection with the different types of the dialog
    /// </summary>
    public enum DialogTypes
    {
        Ok,
        OkCancel,
        Cancel
    }

    /// <summary>
    /// Enum to indicate the position of the dialog
    /// </summary>
    public enum DialogPosition
    {
        Top,
        TopLeft,
        TopRight,
        Bottom,
        BottomLeft,
        BottomRight,
        Center
    }
}
