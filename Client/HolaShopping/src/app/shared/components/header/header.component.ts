import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MessageService } from 'src/app/holashopping/services/messageService';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy {

    subscription: Subscription;

    constructor(
        private router: Router,
        private messageService: MessageService) {
        this.subscription = this.messageService.getMessage().subscribe(message => {
           console.log('mensaje arrived');
        });
    }

    ngOnInit() {
    }

    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }
}
