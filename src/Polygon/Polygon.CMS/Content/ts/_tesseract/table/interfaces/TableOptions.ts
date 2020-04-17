interface TableOptions {
    selectable: boolean;
    hasView: boolean;
    hasEdit: boolean;
    hasDelete: boolean;
    hasSort: boolean;
    requestUrl: string;   
    showRowCount: boolean;
    hasPagination: boolean;
    pageCount: number;
}

export default TableOptions;