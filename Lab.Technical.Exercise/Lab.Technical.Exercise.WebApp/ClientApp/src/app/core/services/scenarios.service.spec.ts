import { TestBed } from '@angular/core/testing';
import { HttpClientModule } from "@angular/common/http";
import {
  HttpClientTestingModule,
  HttpTestingController,
} from "@angular/common/http/testing";

import { ScenariosService } from './scenarios.service';
import { IScenario } from '../models/Scenario';

describe('ScenariosService', () => {
  let service: ScenariosService;
  let httpTestingController: HttpTestingController;
  let mockLoggerService;

  const scenarioTestData: IScenario = {
    "scenarioId": 17,
    "name": "Scenario",
    "forename": "RICHARD GUY L",
    "surname": "WIDDOWSON",
    "networkLayerId": "1",
    "numberOfMonths": 12,
    "sampleDate": new Date(),
    "creationDate": new Date(),
    "marketId": "2",
    "userId": "ECA4A6AA-72FF-4885-9BEB-5B040FC5EF5C"
  }

  const scenariosTestData: IScenario[] = [
    {
      "scenarioId": 1,
      "name": "Scenario1",
      "forename": "EDWARD",
      "surname": "BALDWIN",
      "networkLayerId": "1",
      "numberOfMonths": 12,
      "sampleDate": new Date(),
      "creationDate": new Date(),
      "marketId": "2",
      "userId": "6F55DFD1-A235-4BAE-B958-C1A0AB4D5236"
    },
    {
      "scenarioId": 2,
      "name": "Scenario2",
      "forename": "EDWARD",
      "surname": "BALDWIN",
      "networkLayerId": "1",
      "numberOfMonths": 12,
      "sampleDate": new Date(),
      "creationDate": new Date(),
      "marketId": "2",
      "userId": "6F55DFD1-A235-4BAE-B958-C1A0AB4D5236"
    },
    {
      "scenarioId": 3,
      "name": "Scenario3",
      "forename": "EDWARD",
      "surname": "BALDWIN",
      "networkLayerId": "1",
      "numberOfMonths": 12,
      "sampleDate": new Date(),
      "creationDate": new Date(),
      "marketId": "2",
      "userId": "6F55DFD1-A235-4BAE-B958-C1A0AB4D5236"
    },
    {
      "scenarioId": 4,
      "name": "Scenario4",
      "forename": "EDWARD",
      "surname": "BALDWIN",
      "networkLayerId": "1",
      "numberOfMonths": 12,
      "sampleDate": new Date(),
      "creationDate": new Date(),
      "marketId": "2",
      "userId": "6F55DFD1-A235-4BAE-B958-C1A0AB4D5236"
    },
    {
      "scenarioId": 5,
      "name": "Scenario5",
      "forename": "EDWARD",
      "surname": "BALDWIN",
      "networkLayerId": "1",
      "numberOfMonths": 12,
      "sampleDate": new Date(),
      "creationDate": new Date(),
      "marketId": "2",
      "userId": "6F55DFD1-A235-4BAE-B958-C1A0AB4D5236"
    },
    {
      "scenarioId": 6,
      "name": "Scenario6",
      "forename": "EDWARD",
      "surname": "BALDWIN",
      "networkLayerId": "1",
      "numberOfMonths": 12,
      "sampleDate": new Date(),
      "creationDate": new Date(),
      "marketId": "2",
      "userId": "6F55DFD1-A235-4BAE-B958-C1A0AB4D5236"
    }
  ]

  beforeEach(() => {
    mockLoggerService = jasmine.createSpyObj(["trace"]);
    TestBed.configureTestingModule({
      imports: [HttpClientModule, HttpClientTestingModule],
      providers: [
        ScenariosService
      ]
    });
    service = TestBed.inject(ScenariosService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it("should fetch the correct scenarios", () => {
    service.fetchScenarios().subscribe({
      next: (response) => {
        expect(response).not.toBeNull();
        expect(response.length).toBe(6)
      },
    });
    let request = httpTestingController.expectOne('api/scenarios');
    request.flush(scenariosTestData);
  });

  it("should fetch the correct scenario for given userid", () => {
    service.fetchScenariosByUserId(scenarioTestData.userId).subscribe({
      next: (response) => {
        expect(response).not.toBeNull();
        expect(response.userId).toEqual(scenarioTestData.userId)
        expect(response.scenarioId).toEqual(scenarioTestData.scenarioId)
        expect(response.surname).toEqual(scenarioTestData.surname)
        expect(response.forename).toEqual(scenarioTestData.forename)
      },
    });
    let request = httpTestingController.expectOne(
      `api/scenarios/ByUserId/${scenarioTestData.userId}`
    );
    request.flush(scenarioTestData);
  });
});