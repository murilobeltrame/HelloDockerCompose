import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TodoApiService {

  url: string = 'http://localhost:8111/api/Todos'

  constructor(public http: HttpClient) { }

  get(params?: any, reqOpts?: any) {
    if (!reqOpts) {
      reqOpts = {
        params: new HttpParams()
      };
    }

    // Support easy query params for GET requests
    if (params) {
      reqOpts.params = new HttpParams();
      for (let k in params) {
        reqOpts.params = reqOpts.params.set(k, params[k]);
      }
    }

    return this.http.get(this.url, reqOpts);
  }

  post(body: any, reqOpts?: any) {
    return this.http.post(this.url, body, reqOpts);
  }

  put(body: any, reqOpts?: any) {
    return this.http.put(this.url, body, reqOpts);
  }

  delete(reqOpts?: any) {
    return this.http.delete(this.url, reqOpts);
  }

  patch(body: any, reqOpts?: any) {
    return this.http.patch(this.url, body, reqOpts);
  }
}
