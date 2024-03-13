interface IReportLoadConfiguration {
    embedUrl: string;
    accessToken: string;
    id: string;
    groupId?: string;
    settings?: ISettings;
    bookmark?: IApplyBookmarkRequest;
    pageName?: string;
    filters?: ReportLevelFilters[];
    slicers?: ISlicer[];
    theme?: IReportTheme;
    contrastMode?: ContrastMode;
    datasetBinding?: IDatasetBinding;
    permissions?: Permissions;
    viewMode?: ViewMode;
    tokenType?: TokenType;
}