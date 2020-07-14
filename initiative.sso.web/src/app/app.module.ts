import { MsalModule, MsalInterceptor } from '@azure/msal-angular'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { environment } from 'src/environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms'
import { TestComponent } from './components/test/test.component';
import { TestService } from './services/test.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MarkdownModule } from 'ngx-markdown';
import { DashboardComponent } from './components/dashboard/dashboard.component';

const protectedResourceMap: [string, string[]][] = [
  [environment.api_url, []]
];

@NgModule({
  declarations: [
    AppComponent,
    TestComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    MarkdownModule.forRoot(),
    MsalModule.forRoot({
      authority: "https://login.microsoftonline.com/" + environment.ida_tenant_id,
      clientID: environment.ida_client_id,
      protectedResourceMap: protectedResourceMap,
      redirectUri : environment.ida_redirect,
    }),
    HttpClientModule,
    NgbModule
  ],
  providers: [
    TestService, {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
