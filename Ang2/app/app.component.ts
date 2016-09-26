import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    template: `<h1>My First Angular 2 App</h1>
    <ul>
    <li>1</li>
    <li>2</li>
    <li>3
        <ul>
            <li>3.1</li>
            <li>3.2</li>
        </ul>
        </li>
    <li>4</li>
    <li>5
        <ul>
            <li>5.1</li>
            <li>5.2</li>
            <li>5.3</li>
        </ul>
    </li>
    <li>6</li>
    </ul>`
})
export class AppComponent { }
