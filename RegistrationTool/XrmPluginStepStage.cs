namespace PluginRegistrationTool
{
    /// <summary>
    /// The XRM Plugin Step Stage Enumerator.
    /// Provides XRM Plugin Step Stage values that enumerate.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Xrm"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugin")]
    public enum XrmPluginStepStage
    {
        Invalid = 0,
        PreValidation = 10,
        PreOperation = 20,
        PostOperation = 40,
        PostOperationDeprecated = 50
    }
}
