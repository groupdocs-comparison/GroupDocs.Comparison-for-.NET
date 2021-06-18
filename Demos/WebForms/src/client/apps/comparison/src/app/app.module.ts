import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ComparisonModule } from "@groupdocs.examples.angular/comparison";

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule,
    ComparisonModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
