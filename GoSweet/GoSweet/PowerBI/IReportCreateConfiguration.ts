interface IReportCreateConfiguration {
    accessToken: string;
    datasetId: string;
    embedUrl?: string;
    settings?: models.IEmbedSettings;
    theme?: IReportTheme;
    tokenType?: models.TokenType;
    type: string;
}