export class Todo {
  /**
   *
   */
  constructor(obj: any) {
    Object.assign(this, obj);
  }

  id: string;
  description: string;
  done: boolean;
}
