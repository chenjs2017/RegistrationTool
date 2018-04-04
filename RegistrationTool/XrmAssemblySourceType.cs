namespace PluginRegistrationTool
{
    /// <summary>
    /// The XRM Assembly Source Type Enumerator.
    /// Provides values for XRM Assembly Source Type that enumerate.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Xrm")]
    public enum XrmAssemblySourceType
    {
		Database = 0,
		Disk = 1,
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "GAC")]
        GAC = 2
    }
}
