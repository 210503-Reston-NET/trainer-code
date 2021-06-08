import { review } from "./review";
//note: When creating models, it should reflect the model that you're getting from the api
// that means that the property names and types should be the same as the json file being sent over
export interface restaurant {
    id: number;
    name: string;
    city: string;
    state: string;
    reviews: null | review[]
}