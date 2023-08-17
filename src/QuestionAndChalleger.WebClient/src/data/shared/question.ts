import { category } from "./category";
import { level } from "./level";

export interface question {
  id: number;
  description: string;
  category: category;
  level: level;
}
