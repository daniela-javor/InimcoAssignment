import { SocialNetwork } from './socialNetwork.model';

export interface Person {
    firstName:string;
    lastName:string;
    socialSkills:string[];
    socialNetworks:SocialNetwork[];
}