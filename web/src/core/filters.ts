import { debounce } from "lodash";

export type ReadOnlyFilter = ReadonlySet<string>;

export class Filter extends Set<string> {
  constructor(private filters: Filters) {
    super();
  }

  add(value: string): this {
    super.add(value);
    this.filters.request();
    return this;
  }

  delete(value: string): boolean {
    const result = super.delete(value);
    this.filters.request();
    return result;
  }
}

export class Filters {
  get desired(): Filter {
    return this._desired;
  }

  get banned(): Filter {
    return this._banned;
  }

  public request = debounce(() => {
    console.log("re");
  }, 1000);

  private _desired = new Filter(this);
  private _banned = new Filter(this);
}
