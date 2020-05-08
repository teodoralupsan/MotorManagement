export interface User {
    id: number;
    userName: string;
    email: string;
    created: Date;
    lastActive: Date;
    roles?: string[];
}
