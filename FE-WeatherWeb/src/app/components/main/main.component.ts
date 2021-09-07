import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Country } from 'src/app/models/country.model';
import { City } from 'src/app/models/city.model';
import { ddlOption } from 'src/app/models/ddlOption.model';
import { CityService } from 'src/app/services/city.service';
import { CountryService } from 'src/app/services/country.service';
import { WeatherService } from 'src/app/services/weather.service';
import { Weather } from 'src/app/models/weather.model';
import { WeatherResponse } from 'src/app/models/weatherResponse.model';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  countryList: Country[] = [];
  countryDdl: ddlOption[] = [];
  currCountryId: string;
  selectedCountryId: string;

  cityList: City[] = [];
  cityDdl: ddlOption[] = [];
  currCity: string;
  selectedCity: string;

  isShown: boolean = false;

  weather: WeatherResponse;

  constructor(
    private countryService: CountryService,
    private cityService: CityService,
    private weatherService: WeatherService,
    private messageService: MessageService
  ) { }

  ngOnInit(): void {
    console.log('init');
    this.loadCountryData();
  }

  loadCountryData(){
    console.log('loadCountryData');
    this.countryService
      .getCountryList()
      .subscribe(
        resultStatus => {
          if(resultStatus.isSuccess) {
            console.log('loadCountryData Success');
            this.countryDdl = [];
            this.countryList = resultStatus.resultData;
            this.countryList.forEach(element => {
              let ddlOpt: ddlOption = {
                label: element.countryName,
                value: element.id.toString(),
              };
              this.countryDdl.push(ddlOpt);
            });
            console.log(this.countryDdl);
          }
          else{
            this.messageService.add({
              severity: 'error',
              summary: 'Failed to Get Country List',
              detail: resultStatus.message,
              sticky: false
            })
          }
        },
        error => {
          this.messageService.add({
            severity: 'error', 
            summary: 'Error', 
            detail: error.message,
            sticky: false 
          });
        }
      )
  }

  onCountryChanges(event): void {
    console.log('onCountryChanges');
    console.log(event);
    this.currCountryId = event.value;
    this.loadCityData(this.currCountryId);
  }

  loadCityData(countryId: string){
    console.log('loadCityData');
    this.cityService
      .getCityList(parseInt(countryId))
      .subscribe(
        resultStatus => {
          if(resultStatus.isSuccess) {
            console.log('loadCityData Success');
            this.cityDdl = [];
            this.cityList = resultStatus.resultData;
            this.cityList.forEach(element => {
              let ddlOpt: ddlOption = {
                label: element.cityName,
                value: element.cityName,
              };
              this.cityDdl.push(ddlOpt);
            });
            console.log(this.cityDdl);
          }
          else{
            this.messageService.add({
              severity: 'error',
              summary: 'Failed to Get City List',
              detail: resultStatus.message,
              sticky: false
            })
          }
        },
        error => {
          this.messageService.add({
            severity: 'error', 
            summary: 'Error', 
            detail: error.message,
            sticky: false 
          });
        }
      )
  }

  onCityChanges(event): void {
    console.log('onCityChanges');
    console.log(event);
    this.currCity = event.value;
    this.loadWeatherData(this.currCity);
  }

  loadWeatherData(city: string){
    console.log('loadWeatherData');
    this.weatherService
      .getWeather(city)
      .subscribe(
        resultStatus => {
          console.log(resultStatus);
          if(resultStatus.isSuccess) {
            console.log('loadWeatherData Success');
            this.weather = resultStatus.resultData;
            console.log(this.weather);
            this.isShown = true;
          }
          else{
            this.messageService.add({
              severity: 'error',
              summary: 'Failed to Get Weather Data',
              detail: resultStatus.message,
              sticky: false
            })
          }
        },
        error => {
          this.messageService.add({
            severity: 'error', 
            summary: 'Error', 
            detail: error.message,
            sticky: false 
          });
        }
      )
  }
}
