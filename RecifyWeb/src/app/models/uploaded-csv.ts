export class UploadedCsv {
    id: string;
    clientId: string;
    fileName: string;
    filePath: string;
    uploadDate: Date;
    status: number;
    recommenderToUploadedCsvIds: number[];

    constructor(
        id: string,
        clientId: string,
        fileName: string,
        filePath: string,
        uploadDate: Date,
        status: number,
        recommenderToUploadedCsvIds: number[] = []
    ) {
        this.id = id;
        this.clientId = clientId;
        this.fileName = fileName;
        this.filePath = filePath;
        this.uploadDate = uploadDate;
        this.status = status;
        this.recommenderToUploadedCsvIds = recommenderToUploadedCsvIds;
    }
}