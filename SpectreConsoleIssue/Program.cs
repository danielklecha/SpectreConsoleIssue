using Spectre.Console;
var uri = await new TextPrompt<Uri?>( $"url" )
    .AllowEmpty()
    .Validate( value =>
    {
        if ( !( value?.IsAbsoluteUri ?? true ) )
            return ValidationResult.Error( "[red]It must be absolute url[/]" );
        return ValidationResult.Success();
    } )
    .ShowAsync( AnsiConsole.Console, CancellationToken.None );
if ( uri == null )
    AnsiConsole.WriteLine( "You selected empty value" );
else
    AnsiConsole.WriteLine( $"You selected {uri.AbsoluteUri}" );