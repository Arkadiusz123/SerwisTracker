import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable, Subscription } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { MatSidenav } from '@angular/material/sidenav';
import { AuthenticateService } from '../services/authenticate.service';
import { Router } from '@angular/router';
import { LoadingService } from '../services/loading.service';
import { faPeopleArrows } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppComponent implements OnInit, OnDestroy {
  @ViewChild('sidenav') sidenav!: MatSidenav;
  isLoggedIn: boolean = false;
  menuTools: MenuItem[] = [];
  private subscriptions: Subscription[] = [];

  faPeopleArrows = faPeopleArrows;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver, private authService: AuthenticateService, private router: Router,
    public loadingService: LoadingService) { }
  

  ngOnInit() {
    this.subscriptions.push(this.authService.isLoggedIn().subscribe(x => {
      this.isLoggedIn = x
      this.menuTools = this.menuItems()
    }));
  }

  toggleSidenav() {
    this.sidenav.toggle();
  }

  menuItems(): MenuItem[] {
    const items: MenuItem[] = [];
    
    
    if (this.isLoggedIn) {
      items.push({ route: '', display: 'Wyloguj się', clickAction: 'logout' } as MenuItem)
    }
    else {
      items.push({ route: 'authenticate', display: 'Zaloguj się', clickAction: '' } as MenuItem)
    }

    items.push({ route: 'contact', display: 'Kontakt', clickAction: '' } as MenuItem)

    return items;
  }

  callRouteAction(route: string, funcName: string) {
    if (route) { this.router.navigate([route]); }
    else if (funcName == 'logout') {
      this.authService.logout()
    } 
  }

  title = 'SerwisTracker.client';

  ngOnDestroy() {
    this.subscriptions.forEach(subscription => {
      if (subscription) {
        subscription.unsubscribe();
      }
    });
  }
}

export interface MenuItem {
  display: string;
  route: string;
  clickAction: string;
  id?: number;
}
