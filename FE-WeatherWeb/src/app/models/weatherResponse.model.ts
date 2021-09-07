import { Location } from "./location.model";
import { Temperature } from "./temperature.model";
import { Weather } from "./weather.model";
import { Wind } from "./wind.model";

export class WeatherResponse {
    coord: Location;
    weather: Weather;
    base: string;
    temperatureInKelvin: Temperature;
    temperatureInFahrenheit: Temperature;
    temperatureInCelcius: Temperature;
    pressure: number;
    humidity: number;
    visibility: number;
    wind: Wind;
    clouds: number;
    dateReceiveInUTC: number;
    dateReceive: Date;
    sunrise: Date;
    sunset: Date;
    timeZone: number;
    cityName: string;
}