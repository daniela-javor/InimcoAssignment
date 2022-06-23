import { SocialAccount } from './socialAccount.model';

export interface Person {
    firstName:string;
    lastName:string;
    socialSkills:string[];
    socialAccounts:SocialAccount[];
}