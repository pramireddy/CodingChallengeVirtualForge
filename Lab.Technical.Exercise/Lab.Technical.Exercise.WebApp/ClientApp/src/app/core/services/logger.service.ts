import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoggerService {

  constructor() { }

  log(message: string) {
    // TO DO : Azure AppInsights or any logging system
    console.log("trace:" + message);
  }

  trace(message: string) {
    // TO DO : Azure AppInsights or any logging system
    console.log("trace:" + message);
  }
  error(message: string) {
    // TO DO : Azure AppInsights or any logging system
    console.log("error:" + message);
  }
}