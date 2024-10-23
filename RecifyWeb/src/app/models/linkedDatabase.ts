export class LinkedDatabase {
    id: string;
    clientId: string;
    linkedDatabaseId: string;
    databaseType: number;
    hasViews: boolean;
    hasRatings: boolean;
    databaseConfigurationId: string = '';
    databaseLink: string = '';
    structure: string = '';

    constructor(
        id: string,
        clientId: string,
        linkedDatabaseId: string,
        databaseType: number,
        hasViews: boolean,
        hasRatings: boolean,
        databaseConfigurationId: string = '',
        databaseLink: string = '',
        structure: string = ''
    ) {
        this.id = id;
        this.clientId = clientId;
        this.linkedDatabaseId = linkedDatabaseId;
        this.databaseType = databaseType;
        this.hasViews = hasViews;
        this.hasRatings = hasRatings;
        this.databaseConfigurationId = databaseConfigurationId;
        this.databaseLink = databaseLink;
        this.structure = structure;
    }
}